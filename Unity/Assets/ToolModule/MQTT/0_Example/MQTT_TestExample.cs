using System.Collections.Generic;
using UnityEngine;

namespace MQTT
{
    public class MQTT_TestExample : MonoBehaviour
    {
        public string sendMsg = "sendMsg";

        private async void Start()
        {
            MQTTManager.Instance.AddListener(MessageCode.SyncRobotJoint, TestMsg);
            MQTTManager.Instance.AddListener(MessageCode.SyncIo, TestMsg);
            MQTTManager.Instance.AddListener(MessageCode.UpdateChart, TestMsg);
            MQTTManager.Instance.AddListener(MessageCode.SyncExternalJoint, TestMsg);
            MQTTManager.Instance.AddListener(MessageCode.FanucRobotJoint, TestMsg);
            MQTTManager.Instance.AddListener(MessageCode.ABBRobotJoint, TestMsg);
            MQTTManager.Instance.AddListener(MessageCode.ThreeDWindow, TestMsg);
            MQTTManager.Instance.AddListener(MessageCode.Warning, TestMsg);
            MQTTManager.Instance.AddListener(MessageCode.WarningChange, TestMsg);
            MQTTManager.Instance.AddListener(MessageCode.DeviceStatus, TestMsg);
            MQTTManager.Instance.AddListener(MessageCode.ProcessParameter, TestMsg);
            MQTTManager.Instance.AddListener(MessageCode.FaultStatus, TestMsg);

            List<string> topicListenerList = new List<string>()
        {
            "AAA","BBB","CCC","DDD","EEE"
        };
            MQTTEvent.Instance.StartReceive += async () =>
            {
                await MQTTManager.Instance.SubscribeTopicListAsync(topicListenerList);
            };

            MQTTEvent.Instance.StopReceive += () =>
            {
                Debug.Log("消息停止");
            };

            await MQTTManager.Instance.ConnectAsync();
        }

        private void TestMsg(MQTTDataReceive data)
        {
            Debug.Log($"MsgCode:{data.MsgCode}");

            if (!data.StartDt.Equals(null))
                Debug.Log($"StartDt:{data.StartDt}");

            if (data.Values == null)
                return;

            foreach (var item in data.Values)
            {
                Debug.Log($"Key:{item.Key},Value:{item.Value}");
            }
        }

        private async void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                sendMsg = "{\"MsgCode\":10001,\"WarningMessage\":[\"总装底盘合装线设备状态\",\"前风挡检测机器人扫描NOK\"],\"WarningTime\":\"2024-06-21T14:52:13.4448824+08:00\"}";

                await MQTTManager.Instance.SendMessageAsync("AAA", sendMsg);
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                sendMsg = "{\"MsgCode\":10002,\"WarningMessage\":[],\"WarningTime\":\"2024-06-21T14:41:58.5402912+08:00\"}";
                await MQTTManager.Instance.SendMessageAsync("BBB", sendMsg);
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                sendMsg = "{\"MsgCode\":10003,\"WarningMessage\":[],\"WarningTime\":\"2024-06-21T14:41:58.5402912+08:00\"}";
                await MQTTManager.Instance.SendMessageAsync("CCC", sendMsg);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                sendMsg = "{\"MsgCode\":1004,\"StartDt\":\"2024-06-21 14:52:13.442\",\"Values\":[{\"Key\":\"总装底盘合装线设备状态\",\"Value\":false},{\"Key\":\"前风挡检测机器人扫描NOK\",\"Value\":false},{\"Key\":\"前风挡胶型检测OK\",\"Value\":false},{\"Key\":\"前风挡胶型检测NOK\",\"Value\":false},{\"Key\":\"前风挡胶塔清洁OK\",\"Value\":false},{\"Key\":\"前风挡胶塔涂胶OK\",\"Value\":false},{\"Key\":\"前风挡胶塔涂胶NOK\",\"Value\":false},{\"Key\":\"后风挡检测机器人扫描OK\",\"Value\":false},{\"Key\":\"后风挡检测机器人扫描NOK\",\"Value\":false},{\"Key\":\"后挡胶型检测OK\",\"Value\":false},{\"Key\":\"后挡胶型检测NOK\",\"Value\":false},{\"Key\":\"后挡胶塔清洁OK\",\"Value\":false},{\"Key\":\"后挡胶塔涂胶OK\",\"Value\":false},{\"Key\":\"后挡胶塔涂胶NOK\",\"Value\":false}],\"EndDt\":\"2024-06-21 14:52:13.443\"}";

                await MQTTManager.Instance.SendMessageAsync("DDD", sendMsg);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                sendMsg = "{\"StartDt\":\"2024-06-21 14:52:13.442\",\"MsgCode\":10007,\"Values\":[{\"Key\":\"总装底盘合装线设备状态\",\"Value\":false},{\"Key\":\"前风挡检测机器人扫描NOK\",\"Value\":false},{\"Key\":\"前风挡胶型检测OK\",\"Value\":false},{\"Key\":\"前风挡胶型检测NOK\",\"Value\":false},{\"Key\":\"前风挡胶塔清洁OK\",\"Value\":false},{\"Key\":\"前风挡胶塔涂胶OK\",\"Value\":false},{\"Key\":\"前风挡胶塔涂胶NOK\",\"Value\":false},{\"Key\":\"后风挡检测机器人扫描OK\",\"Value\":false},{\"Key\":\"后风挡检测机器人扫描NOK\",\"Value\":false},{\"Key\":\"后挡胶型检测OK\",\"Value\":false},{\"Key\":\"后挡胶型检测NOK\",\"Value\":false},{\"Key\":\"后挡胶塔清洁OK\",\"Value\":false},{\"Key\":\"后挡胶塔涂胶OK\",\"Value\":false},{\"Key\":\"后挡胶塔涂胶NOK\",\"Value\":false}],\"EndDt\":\"2024-06-21 14:52:13.443\"}";
                await MQTTManager.Instance.SendMessageAsync("EEE", sendMsg);
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