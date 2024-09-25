using SimpleFrame;
using System;

namespace MQTT
{
    public class MQTTEvent : ThreadSingleton<MQTTEvent>
    {
        public Action StartReceive;
        public Action StopReceive;
    }
}