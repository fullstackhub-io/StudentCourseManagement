namespace CourseBasket.Application.CoursesBasket.VM
{
    using AutoMapper;
    using CourseBasket.Application.Common.Mappings;
    using CourseBasket.Domain.Entities;
    using System.Linq;

    public class CourseBasketVM : IMapFrom<BasketCart>
    {
        public string UserEmail { get; set; }
        public string Subjects { get; set; }
        public decimal TotalPrice { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<CourseBasketVM, BasketCart>();
            profile.CreateMap<BasketCart, CourseBasketVM>()
                .ForMember(d => d.Subjects, e => e.MapFrom(s => string.Join(",", s.Items.Select(x => x.CourseName).ToArray())));
        }
    }
}
