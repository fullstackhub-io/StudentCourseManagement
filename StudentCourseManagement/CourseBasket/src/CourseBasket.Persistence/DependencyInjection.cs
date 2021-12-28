using CourseBasket.Application.Common.Interfaces;
using CourseBasket.Domain.UnitOfWork;
using CourseBasket.Persistence.Constant;
using EventBusRabbitMQ.Producer;
using EventBusRabbitMQ.RabbitMQConnection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using StackExchange.Redis;

namespace CourseBasket.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfigConstants, ConfigConstants>();
            services.AddTransient<IUnitOfWork>(uof => new UnitOfWork.UnitOfWork(ConnectionMultiplexer.Connect(ConfigurationOptions.Parse(uof.GetService<IConfigConstants>().RedisConnection, true)).GetDatabase()));
            services.AddSingleton<IRabbitMQConnection>(sp =>
            {
                var factory = new ConnectionFactory()
                {
                    HostName = configuration["EventBus:HostName"]
                };

                if (!string.IsNullOrEmpty(configuration["EventBus:UserName"]))
                {
                    factory.UserName = configuration["EventBus:UserName"];
                }

                if (!string.IsNullOrEmpty(configuration["EventBus:Password"]))
                {
                    factory.Password = configuration["EventBus:Password"];
                }

                return new RabbitMQConnection(factory);
            });

            services.AddSingleton<EventBusRabbitMQProducer>();
            return services;
        }
    }
}
