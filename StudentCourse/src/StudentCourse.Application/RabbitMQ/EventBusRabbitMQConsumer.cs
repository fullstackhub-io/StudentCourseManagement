﻿using AutoMapper;
using EventBusRabbitMQ.Events;
using EventBusRabbitMQ.RabbitMQConnection;
using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StudentCourse.Application.StudentCourse.DTO;
using StudentCourse.Application.User.Commands;
using System.Collections.Generic;
using System.Text;

namespace StudentCourse.Application.RabbitMQ
{
    public class EventBusRabbitMQConsumer
    {
        private readonly IRabbitMQConnection connection;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public EventBusRabbitMQConsumer(IRabbitMQConnection connection, IMediator mediator, IMapper mapper)
        {
            this.connection = connection;
            this.mediator = mediator;
            this.mapper = mapper;
        }

        public void Consume()
        {
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: EventBusRabbitMQ.Common.Constants.CourseCheckoutQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += ReceivedEvent;

            channel.BasicConsume(queue: EventBusRabbitMQ.Common.Constants.CourseCheckoutQueue, autoAck: true, consumer: consumer);
        }

        private async void ReceivedEvent(object sender, BasicDeliverEventArgs e)
        {
            if (e.RoutingKey == EventBusRabbitMQ.Common.Constants.CourseCheckoutQueue)
            {
                var message = Encoding.UTF8.GetString(e.Body.Span);
                var basketCheckoutEvent = JsonConvert.DeserializeObject<CourseCheckoutEvent>(message);
                var command = mapper.Map(basketCheckoutEvent, new List<StudentCourseDTO>());
                var addStudentCourseCommand = new AddStudentCourseCommand
                {
                    //Address = command.Address,
                    //EmailAddress = command.EmailAddress,
                    //FirstName = command.FirstName,
                    //LastName = command.LastName,
                    //PhoneNumber = command.PhoneNumber,
                    //Subjects = command.Subjects,
                    //TotalPrice = command.TotalPrice,
                    Courses = command
                };
                var result = await mediator.Send(addStudentCourseCommand);
            }
        }

        public void Disconnect()
        {
            connection.Dispose();
        }
    }
}
