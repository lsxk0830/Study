using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using SimpleFrame;
using UnityEngine;

namespace MQTT
{
    /// <summary>
    /// 功能说明：
    /// MQTT连接、断连 : Connect、DisconnectAsync
    /// Topic监听：SubscribeTopic、SubscribeTopicList、UnsubscribeTopic、UnsubscribeAllTopic
    /// 消息类型监听：AddListener【用于消息分发】
    /// 往外发送消息：SendMessage
    /// </summary>
    public class MQTTManager : ThreadSingleton<MQTTManager>, IDisposable
    {
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        public MQTTClient Client { get; set; }

        public bool IsCanRecv
        {
            get => isCanRecv;
            set => isCanRecv = value;
        }

        public bool ConnectionStatus => Client == null ? false : Client.IsConnect;

        private Dictionary<MessageCode, Action<MQTTDataReceive>> msgCodeListenerDic =
            new Dictionary<MessageCode, Action<MQTTDataReceive>>();

        private ConcurrentDictionary<MessageCode, ConcurrentQueue<MQTTDataReceive>> ProcessedMsgQueueByMsgCode =
            new ConcurrentDictionary<MessageCode, ConcurrentQueue<MQTTDataReceive>>(); // 处理后的消息队列

        private ConcurrentQueue<string> ReceiveOriginalMsgQueue = new ConcurrentQueue<string>(); // 源消息队列

        private const int MsgHandleTaskCount = 6;
        private List<Task> msgHandlerTaskList = new List<Task>();
        private HashSet<string> subscribeTopicHashSet = new HashSet<string>();

        public async Task ConnectAsync()
        {
            Init();

            if (Client == null)
                Client = string.IsNullOrEmpty(username) ? new MQTTClient(ip, port) : new MQTTClient(ip, port, username, password);

            if (Client != null && !Client.IsConnect)
                await Client.ConnectAsync();

            CanReceive(true);
        }

        public async Task DisconnectAsync()
        {
            CanReceive(false);
            await Client?.DisconnectAsync();
        }

        public void AddListener(MessageCode msgCode, Action<MQTTDataReceive> messageHandler)
        {
            if (msgCodeListenerDic.ContainsKey(msgCode))
                return;
            msgCodeListenerDic.Add(msgCode, messageHandler);
        }

        #region 消息监听

        public async Task SubscribeTopicAsync(string topic)
        {
            if (Client == null || !Client.IsConnect || !subscribeTopicHashSet.Add(topic)) return;
            await Client.SubscribeAsync(topic);
        }

        public async Task SubscribeTopicListAsync(IEnumerable<string> topicList)
        {
            if (Client == null || !Client.IsConnect || !IsCanRecv) return;
            var tasks = new List<Task>();
            foreach (string topic in topicList)
            {
                if (subscribeTopicHashSet.Add(topic))
                {
                    tasks.Add(Client.SubscribeAsync(topic));
                }
            }
            await Task.WhenAll(tasks);
        }

        public async Task UnsubscribeTopicAsync(string topic)
        {
            if (subscribeTopicHashSet.Count == 0 || !subscribeTopicHashSet.Contains(topic) ||
                Client == null || !Client.IsConnect)
                return;

            await Client.Unsubscribe(topic);
            subscribeTopicHashSet.Remove(topic);
        }

        public async Task UnsubscribeAllTopicAsync()
        {
            if (subscribeTopicHashSet.Count == 0 || Client == null || !Client.IsConnect)
                return;

            var tasks = new List<Task>();
            foreach (var topic in subscribeTopicHashSet)
            {
                tasks.Add(UnsubscribeTopicAsync(topic));
            }
            await Task.WhenAll(tasks);
            subscribeTopicHashSet.Clear();
        }

        #endregion 消息监听

        public async Task SendMessageAsync(string topic, string sendData)
        {
            if (Client == null || !Client.IsConnect || !IsCanRecv) return;
            await Client.Publish(topic, sendData);
        }

        #region 内部代码

        private string ip;
        private int port;
        private string username;
        private string password;
        private bool isCanRecv = false;
        private ActiveMQTT activeMQTT;

        private void Init()
        {
            if (Client != null) return;

            if (activeMQTT == null)
            {
                GameObject go = new GameObject("ActiveMQTT");
                go.AddComponent<ActiveMQTT>();
                GameObject.DontDestroyOnLoad(go);
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Application.streamingAssetsPath + "/MqttConfig.xml");
            XmlNode root = xmlDoc.DocumentElement;
            XmlNode ip = root.SelectSingleNode("ip");
            XmlNode port = root.SelectSingleNode("port");
            XmlNode passworld = root.SelectSingleNode("passworld");
            string NowUsername = string.Empty;

            XmlNode username = root.SelectSingleNode("username1");

            if (string.IsNullOrEmpty(ip.InnerText) || string.IsNullOrEmpty(port.InnerText)) return;

            if (username.InnerText != "null" && passworld.InnerText != "null")
                SetCredential(username.InnerText, passworld.InnerText);
            SetIpAddress(ip.InnerText, int.Parse(port.InnerText));
            Debug.Log($"UserName:{username.InnerText},Password:{passworld.InnerText},IP:{ip.InnerText},Port:{port.InnerText}");
        }

        private void CanReceive(bool canRecv)
        {
            if (canRecv == isCanRecv) return;
            isCanRecv = canRecv;
            if (isCanRecv)
            {
                MQTTEvent.Instance.StartReceive?.Invoke();
                StartMessageHandlers();
            }
            else
            {
                MQTTEvent.Instance.StopReceive?.Invoke();
                StopMessageHandlers();
            }
        }

        private void StartMessageHandlers()
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource.Dispose();
            }
            cancellationTokenSource = new CancellationTokenSource();
            msgHandlerTaskList.Clear();
            for (int i = 0; i < MsgHandleTaskCount; i++)
                msgHandlerTaskList.Add(Task.Run(() => AcceptMsgHandler(cancellationTokenSource.Token)));
        }

        private void StopMessageHandlers()
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource.Dispose();
                cancellationTokenSource = null;
            }
            Task.WhenAll(msgHandlerTaskList).Wait();
            msgHandlerTaskList.Clear();
            ReceiveOriginalMsgQueue.Clear();
            ProcessedMsgQueueByMsgCode.Clear();
        }

        private async void AcceptMsgHandler(CancellationToken token)
        {
            List<string> messages = new List<string>();
            while (!token.IsCancellationRequested)
            {
                try
                {
                    messages.Clear();
                    while (messages.Count < 100 && ReceiveOriginalMsgQueue.TryDequeue(out var message))
                        messages.Add(message);

                    foreach (var msg in messages)
                    {
                        try
                        {
                            MQTTDataReceive mqttDataModel = JsonConvert.DeserializeObject<MQTTDataReceive>(msg);
                            if (mqttDataModel != null)
                            {
                                ProcessedMsgQueueByMsgCode.GetOrAdd(mqttDataModel.MsgCode, _ => new ConcurrentQueue<MQTTDataReceive>())
                                                          .Enqueue(mqttDataModel);
                            }
                            else
                                Debug.LogError($"Failed to deserialize message: {msg}");
                        }
                        catch (JsonException jsonEx)
                        {
                            Debug.LogError($"消息：{msg}。JSON parse error: {jsonEx}");
                        }
                        catch (Exception ex)
                        {
                            Debug.LogError($"Message processing error: {ex}");
                        }
                    }
                    //Debug.Log($"当前线程：{Thread.CurrentThread.ManagedThreadId}");
                    int delayTime = messages.Count > 0 ? 20 : 100;
                    await Task.Delay(delayTime);
                }
                catch (Exception ex)
                {
                    Debug.LogError($"AcceptMsgHandler error: {ex}");
                }
            }
        }

        public void ReceiveMessage(byte[] payload)
        {
            if (!isCanRecv)
                return;
            string message = Encoding.UTF8.GetString(payload);
            ReceiveOriginalMsgQueue.Enqueue(message);
        }

        ~MQTTManager()
        {
            DisposeMsgRecv();
            Client.Dispose();
        }

        public void Dispose()
        {
            StopMessageHandlers();
            Client?.Dispose();
            cancellationTokenSource?.Dispose();
            GC.SuppressFinalize(this);
        }

        private void DisposeMsgRecv()
        {
            isCanRecv = false;
            cancellationTokenSource.Cancel();
            foreach (var item in msgHandlerTaskList)
            {
                item.Wait();
                item?.Dispose();
            }
            msgHandlerTaskList.Clear();
            ReceiveOriginalMsgQueue.Clear();
            ProcessedMsgQueueByMsgCode.Clear();
        }

        private void SetIpAddress(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }

        private void SetCredential(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public class ActiveMQTT : MonoBehaviour
        {
            private int count = 0;

            private void FixedUpdate()
            {
                foreach (var processedMsgQueue in Instance.ProcessedMsgQueueByMsgCode)
                {
                    int count = 0;
                    while (count < 100 && processedMsgQueue.Value.Count > 0 && processedMsgQueue.Value.TryDequeue(out MQTTDataReceive executeMsg))
                    {
                        if (Instance.msgCodeListenerDic.TryGetValue(processedMsgQueue.Key, out var handler))
                        {
                            handler?.Invoke(executeMsg);
                        }
                        count++;
                    }
                }
            }

            private void OnApplicationQuit()
            {
                Instance.Dispose();
            }
        }

        #endregion 内部代码

        public void DebugTopics()
        {
            foreach (var topic in subscribeTopicHashSet)
            {
                Debug.LogWarning($"{topic}");
            }
        }
    }
}