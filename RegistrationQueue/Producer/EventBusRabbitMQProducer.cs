using EventBusRabbitMQ.Events;
using EventBusRabbitMQ.RabbitMQConnection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Collections.Generic;
using System.Text;

namespace EventBusRabbitMQ.Producer
{
    public class EventBusRabbitMQProducer
    {
        private readonly IRabbitMQConnection connection;

        public EventBusRabbitMQProducer(IRabbitMQConnection connection)
        {
            this.connection = connection;
        }

        public void PublishCoursesCheckout(string queueName, List<CourseCheckoutEvent> publishModel)
        {
            using var channel = this.connection.CreateModel();
            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            var message = JsonConvert.SerializeObject(publishModel);
            var body = Encoding.UTF8.GetBytes(message);

            IBasicProperties properties = channel.CreateBasicProperties();
            properties.Persistent = true;
            properties.DeliveryMode = 2;

            channel.ConfirmSelect();
            channel.BasicPublish(exchange: "", routingKey: queueName, mandatory: true, basicProperties: properties, body: body);
            channel.WaitForConfirmsOrDie();

            channel.BasicAcks += (sender, eventArgs) =>
            {
                System.Console.WriteLine("Sent RabbitMQ");
                //implement ack handle
            };
            channel.ConfirmSelect();
        }
    }
}
