using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace MQTT
{
    public class MQTT_TestExample : MonoBehaviour
    {
        public string topic = "AAA";
        public string sendMsg = "{\"MsgCode\":10001,\"message\":\"这是一个消息\"}";

        private async void Start()
        {
            MQTTManager.Instance.AddListener(MessageCode.Log, TestMsg);
            MQTTManager.Instance.AddListener(MessageCode.Warning, TestMsg);
            MQTTManager.Instance.AddListener(MessageCode.Error, TestMsg);

            List<string> topicListenerList = new List<string>()
            {
                "AAA","BBB","CCC","DDD","EEE"
            };
            MQTTEvent.Instance.StartReceive += async () =>
            {
                Debug.Log($"监听Topic");
                await MQTTManager.Instance.SubscribeTopicListAsync(topicListenerList);
            };

            MQTTEvent.Instance.StopReceive += () =>
            {
                Debug.Log("消息停止");
            };

            await MQTTManager.Instance.ConnectAsync("broker.emqx.io", 1883, "lsxk", "0830");
        }

        private void TestMsg(MQTTDataReceive data)
        {
            Debug.Log($"MsgCode:{data.MsgCode},消息：{data.message}");
        }

        public async void BtnClick()
        {
            await MQTTManager.Instance.SendMessageAsync(topic, sendMsg);
        }

        private async void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                sendMsg = "{\"MsgCode\":10001,\"message\":\"这是一个消息\"}";

                await MQTTManager.Instance.SendMessageAsync("AAA", sendMsg);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                await MQTTManager.Instance.DisconnectAsync();
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                await MQTTManager.Instance.ConnectAsync();
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                MQTTManager.Instance.IsCanRecv = false;
            }
        }
    }
}