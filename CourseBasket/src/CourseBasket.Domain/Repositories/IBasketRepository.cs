using CourseBasket.Domain.Entities;
using EventBusRabbitMQ.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseBasket.Domain.Repositories
{
    public interface IBasketRepository
    {
        Task<List<BasketCart>> GetAllItemBasket(List<string> userNames);
        Task<BasketCart> GetBasket(string userName);
        Task<bool> UpdateBasket(BasketCart basket);
        Task<bool> DeleteBasket(string userName);

        Task<bool> CheckoutBasket(CourseCheckoutEvent coursesCheckoutEvent);
    }
}
