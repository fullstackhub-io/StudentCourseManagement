using AutoMapper;
using System;
using StudentCourse.Application.Common.Mappings;
using StudentCourseEntity = StudentCourse.Domain.Entities.StudentCourse;

namespace StudentCourse.Application.StudentCourse.DTO
{
    public class StudentCourseDTO : IMapFrom<StudentCourseEntity>
    {
        public int StudentCourseID { get; set; }

        public string CourseName { get; set; }

        public string CrouseShortName { get; set; }
        public decimal CreditHour { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

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
        }
    }
}
