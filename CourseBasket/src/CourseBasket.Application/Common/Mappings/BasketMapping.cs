using AutoMapper;
using CourseBasket.Domain.Entities;
using EventBusRabbitMQ.Events;

namespace CourseBasket.Application.Common.Mappings
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            CreateMap<BasketCheckout, CourseCheckoutEvent>().ReverseMap();
        }
    }
}
