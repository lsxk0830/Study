using System.Collections.Generic;

namespace MQTT
{
    /// <summary>
    /// MQTT消息接收
    /// </summary>
    public class MqttMessageReceive:CommMessageReceive
    {
        public void ReceiveData<T>(Dictionary<int, MqttDataModel<T>> receiveData)
        {
            
        }
    }

    public class CommMessageReceive
    {
    }
}