namespace Course.Application.Course.DTO
{
    using AutoMapper;
    using System;
    using global::Course.Domain.Entities;
    using global::Course.Application.Common.Mappings;

    public class CourseDTO : IMapFrom<Course>
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseShortName { get; set; }
        public double CreditHour { get; set; }
        public double Price { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CourseDTO, Course>();
            profile.CreateMap<Course, CourseDTO>();
        }
    }
}
