using AutoMapper;
using EventBusRabbitMQ.Events;
using StudentCourse.Application.Common.Mappings;

namespace StudentCourse.Application.StudentCourse.DTO
{
    public class StudentCourseCommand : IMapFrom<CourseCheckoutEvent>
    {
        public string CourseName { get; set; }
        public string CrouseShortName { get; set; }
        public decimal CreditHour { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<StudentCourseDTO, CourseCheckoutEvent>().ReverseMap();
        }
    }
}
