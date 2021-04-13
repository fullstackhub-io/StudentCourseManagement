using CourseBasket.Domain.Repositories;
using CourseBasket.Domain.UnitOfWork;
using CourseBasket.Persistence.Repositories;
using EventBusRabbitMQ.Producer;
using StackExchange.Redis;

namespace CourseBasket.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IDatabase redisDB)
        {
            this.RedisDB = redisDB;
        }

        public IDatabase RedisDB { get; }
        public EventBusRabbitMQProducer EventBusRabbitMQProducer { get; }
        public IBasketRepository Basket => new BasketRepository(RedisDB, EventBusRabbitMQProducer);
    }
}
