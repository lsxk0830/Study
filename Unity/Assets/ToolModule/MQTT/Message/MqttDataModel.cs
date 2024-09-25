using System.Collections.Generic;
using DateTime = System.DateTime;

namespace MQTT
{
    /// <summary>
    /// MQTT数据接收时Json数据转换
    /// </summary>
    public class MQTTDataReceive : MqttDataModel<List<KeyValuePair<string, object>>>
    {
    }

    public class MqttDataModel<T>
    {
        /// <summary>
        /// 接收数据的开始时间-采集端
        /// </summary>
        public DateTime StartDt { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public MessageCode MsgCode { get; set; }

        /// <summary>
        /// 报警数据——当非报警类型消息时为空
        /// </summary>
        public List<string> WarningMessage { get; set; }

        /// <summary>
        /// 具体值
        /// </summary>
        public T Values { get; set; }

        /// <summary>
        /// 唯一标志  数据ID
        /// </summary>
        public int DataID { get; set; }

        /// <summary>
        /// 当前设备是否故障的状态值
        /// 只有当  code= 10012/10014 有赋值，否则为空
        /// </summary>
        public bool IsFault { get; set; }

        /// <summary>
        /// 接收数据的结束时间-采集端
        /// </summary>
        public DateTime EndDt { get; set; }
    }

    public enum MessageCode : short
    {
        SyncRobotJoint = 10001,     //Kuka机器人
        SyncIo = 10002,             //IO设备
        UpdateChart = 10003,        //采集设备
        SyncExternalJoint = 1004,   //动作设备
        FanucRobotJoint = 10007,    //Fanuc机器人
        ABBRobotJoint = 10008,      //ABB机器人
        ThreeDWindow = 10009,        //3D弹窗
        Warning = 10010,             //告警
        WarningChange = 10011,       //变化告警
        DeviceStatus = 10012,       //设备状态
        ProcessParameter = 10013,   //工艺参数
        FaultStatus = 10014         //故障状态
    }
}