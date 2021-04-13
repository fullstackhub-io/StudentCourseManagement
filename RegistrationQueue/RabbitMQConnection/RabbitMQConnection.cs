using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Threading;

namespace EventBusRabbitMQ.RabbitMQConnection
{
    public class RabbitMQConnection : IRabbitMQConnection
    {
        private bool disposedValue;
        private readonly IConnectionFactory connectionFactory;
        private IConnection connection;

        public RabbitMQConnection(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
            if (!IsConnected)
            {
                TryConnect();
            }
        }

        public bool IsConnected => connection != null && connection.IsOpen && !disposedValue;

        public IModel CreateModel()
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("No rabbit MQ connection");
            }

            return connection.CreateModel();
        }

        public bool TryConnect()
        {
            try
            {
                connection = this.connectionFactory.CreateConnection();
            }
            catch (BrokerUnreachableException)
            {
                Thread.Sleep(2000);
                connection = this.connectionFactory.CreateConnection();
            }

            if (IsConnected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.connection.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }
    }
}
