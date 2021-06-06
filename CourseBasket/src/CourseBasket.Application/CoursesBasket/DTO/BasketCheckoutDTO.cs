namespace CourseBasket.Application.CoursesBasket.DTO
{
    using AutoMapper;
    using CourseBasket.Application.Common.Mappings;
    using CourseBasket.Domain.Entities;
    using EventBusRabbitMQ.Events;

    public class BasketCheckoutDTO : IMapFrom<BasketCheckout>, IMapFrom<CourseCheckoutEvent>
    {
        public string Subjects { get; set; }
        public decimal TotalPrice { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BasketCheckout, BasketCheckoutDTO>();
            profile.CreateMap<BasketCheckoutDTO, BasketCheckout>();

            profile.CreateMap<CourseCheckoutEvent, BasketCheckoutDTO>();
            profile.CreateMap<BasketCheckoutDTO, CourseCheckoutEvent>();
        }
    }
}
