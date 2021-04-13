using CourseBasket.Domain.Entities;
using CourseBasket.Domain.Repositories;
using EventBusRabbitMQ.Common;
using EventBusRabbitMQ.Events;
using EventBusRabbitMQ.Producer;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Threading.Tasks;

namespace CourseBasket.Persistence.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase redisConn;
        private readonly EventBusRabbitMQProducer eventBusRabbitMQProducer;

        public BasketRepository(IDatabase redisConn, EventBusRabbitMQProducer eventBusRabbitMQProducer)
        {
            this.redisConn = redisConn;
            this.eventBusRabbitMQProducer = eventBusRabbitMQProducer;
        }
        public async Task<bool> DeleteBasket(string userName)
        {
            return await this.redisConn.KeyDeleteAsync(userName);
        }

        public async Task<BasketCart> GetBasket(string userName)
        {
            var basket = await this.redisConn.StringGetAsync(userName);

            if (basket.IsNullOrEmpty)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<BasketCart>(basket);
        }

        public async Task<BasketCart> UpdateBasket(BasketCart basket)
        {
            var updated = await this.redisConn.StringSetAsync(basket.UserEmail, JsonConvert.SerializeObject(basket));

            if (!updated)
            {
                return null;
            }

            return await GetBasket(basket.UserEmail);
        }

        public Task<bool> CheckoutBasket(CourseCheckoutEvent coursesCheckoutEvent)
        {
            this.eventBusRabbitMQProducer.PublishCoursesCheckout(Constants.CourseCheckoutQueue, coursesCheckoutEvent);
            return Task.Run(() => true);
        }
    }
}
