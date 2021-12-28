using CourseBasket.Domain.Entities;
using CourseBasket.Domain.Repositories;
using EventBusRabbitMQ.Common;
using EventBusRabbitMQ.Events;
using EventBusRabbitMQ.Producer;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<BasketCart>> GetAllItemBasket(List<string> userNames)
        {
            List<BasketCart> baskets = new List<BasketCart>();
            foreach (var userName in userNames)
            {
                var item = GetBasket(userName).Result;
                if (item != null)
                {
                    baskets.Add(GetBasket(userName).Result);
                }
            }
            return await Task.Run(() => baskets);
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

        public async Task<bool> UpdateBasket(BasketCart basket)
        {
            var updated = await this.redisConn.StringSetAsync(basket.UserEmail, JsonConvert.SerializeObject(basket));

            if (!updated)
            {
                return false;
            }

            return await Task.Run(() => true);
        }

        public Task<bool> CheckoutBasket(List<CourseCheckoutEvent> coursesCheckoutEvent)
        {
            this.eventBusRabbitMQProducer.PublishCoursesCheckout(Constants.CourseCheckoutQueue, coursesCheckoutEvent);
            return Task.Run(() => true);
        }
    }
}
