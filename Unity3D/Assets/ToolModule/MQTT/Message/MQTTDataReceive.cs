namespace MQTT
{
    /// <summary>
    /// MQTT数据接收时Json数据转换
    /// </summary>
    public class MQTTDataReceive
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public MessageCode MsgCode { get; set; }

        /// <summary>
        /// 具体消息
        /// </summary>
        public string message { get; set; }
    }
}