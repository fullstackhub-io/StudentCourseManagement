using AutoMapper;
using System;
using StudentCourse.Application.Common.Mappings;
using StudentCourseEntity = StudentCourse.Domain.Entities.StudentCourse;
using EventBusRabbitMQ.Events;

namespace StudentCourse.Application.StudentCourse.DTO
{
    public class StudentCourseDTO : IMapFrom<StudentCourseEntity>, IMapFrom<CourseCheckoutEvent>
    {
        public int StudentCourseID { get; set; }
        public string Subjects { get; set; }
        public decimal TotalPrice { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public DateTime SessionStartDate { get; set; }

        public DateTime SessionEndDate { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateUpdated { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<StudentCourseDTO, StudentCourseEntity>();
            profile.CreateMap<StudentCourseEntity, StudentCourseDTO>();

            profile.CreateMap<StudentCourseDTO, CourseCheckoutEvent>();
            profile.CreateMap<CourseCheckoutEvent, StudentCourseDTO>();
        }
    }
}
