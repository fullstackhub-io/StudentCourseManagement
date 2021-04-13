using CourseBasket.Domain.Entities;
using EventBusRabbitMQ.Events;
using System.Threading.Tasks;

namespace CourseBasket.Domain.Repositories
{
    public interface IBasketRepository
    {
        Task<BasketCart> GetBasket(string userName);
        Task<BasketCart> UpdateBasket(BasketCart basket);
        Task<bool> DeleteBasket(string userName);

        Task<bool> CheckoutBasket(CourseCheckoutEvent coursesCheckoutEvent);
    }
}
