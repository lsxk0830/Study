using System;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Formatter;
using UnityEngine;

namespace MQTT
{
    public class MQTTClient
    {
        private IMqttClient _mqttClient;
        private MqttClientOptions _options;
        private string _clientId;
        public Action<byte[]> OnMessageReceived;

        public MQTTClient(string ip, int port)
        {
            _clientId = Guid.NewGuid().ToString();
            _options = new MqttClientOptionsBuilder()
                .WithClientId(_clientId)
                .WithTcpServer(ip, port)
                .WithTimeout(TimeSpan.FromSeconds(5))
                .WithKeepAlivePeriod(TimeSpan.FromSeconds(60))
                .WithProtocolVersion(MqttProtocolVersion.V500)
                .WithCleanSession(true)
                .Build();
            _mqttClient = new MqttFactory().CreateMqttClient();
            _mqttClient.ApplicationMessageReceivedAsync += MqttClient_ApplicationMessageReceivedAsync;
            _mqttClient.DisconnectedAsync += MqttClient_DisconnectedAsync;
            _mqttClient.ConnectedAsync += MqttClient_ConnectedAsync;
        }

        public MQTTClient(string ip, int port, string username, string pwd)
        {
            _clientId = Guid.NewGuid().ToString();
            _options = new MqttClientOptionsBuilder()
                .WithClientId(_clientId)
                .WithTcpServer(ip, port)
                .WithCredentials(username, pwd)
                .WithTimeout(TimeSpan.FromSeconds(5))
                .WithKeepAlivePeriod(TimeSpan.FromSeconds(60))
                .WithProtocolVersion(MqttProtocolVersion.V500)
                .WithCleanSession(true)
                .Build();
            _mqttClient = new MqttFactory().CreateMqttClient();
            _mqttClient.ApplicationMessageReceivedAsync += MqttClient_ApplicationMessageReceivedAsync;
            _mqttClient.ConnectedAsync += MqttClient_ConnectedAsync;
            _mqttClient.DisconnectedAsync += MqttClient_DisconnectedAsync;
        }

        private Task MqttClient_ConnectedAsync(MqttClientConnectedEventArgs args)
        {
            Debug.Log($"MQTT==>Connected={args.ConnectResult.ResultCode}");
            return Task.CompletedTask;
        }

        private async Task MqttClient_DisconnectedAsync(MqttClientDisconnectedEventArgs args)
        {
            try
            {
                Debug.Log("MQTT==>Disconnected");
                await _mqttClient.ConnectAsync(_options);
            }
            catch (Exception e)
            {
                Debug.Log($"MQTT重连失败{e}");
            }
        }

        private async Task MqttClient_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg)
        {
            MQTTManager.Instance.ReceiveMessage(arg.ApplicationMessage.PayloadSegment.Array);
            await Task.Yield();
        }

        public bool IsConnect => _mqttClient == null ? false : _mqttClient.IsConnected;

        public void Dispose()
        {
            _mqttClient.Dispose();
        }

        public async Task ConnectAsync()
        {
            await _mqttClient.ConnectAsync(_options, default);
        }

        public async Task DisconnectAsync()
        {
            await _mqttClient.DisconnectAsync();
        }

        public async Task SubscribeAsync(string topic)
        {
            var mqttSubscribeOptions = new MqttFactory().CreateSubscribeOptionsBuilder().WithTopicFilter(f => f.WithTopic(topic).Build()).Build();
            await _mqttClient.SubscribeAsync(mqttSubscribeOptions, default);
        }

        public async Task Unsubscribe(string topic)
        {
            var mqttUnsubscribeOptions = new MqttFactory().CreateUnsubscribeOptionsBuilder().WithTopicFilter(topic).Build();
            await _mqttClient.UnsubscribeAsync(mqttUnsubscribeOptions, default);
        }

        public Task Publish(string topic, string sendData)
        {
            var bytes = Encoding.UTF8.GetBytes(sendData);
            return _mqttClient.PublishAsync(new MqttApplicationMessage()
            {
                Topic = topic,
                PayloadSegment = new ArraySegment<byte>(bytes)
            });
        }
    }
}