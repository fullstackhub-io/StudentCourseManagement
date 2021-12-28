using RabbitMQ.Client;
using System;

namespace EventBusRabbitMQ.RabbitMQConnection
{
    public interface IRabbitMQConnection : IDisposable
    {
        bool IsConnected { get; }
        bool TryConnect();
        IModel CreateModel();
    }
}
