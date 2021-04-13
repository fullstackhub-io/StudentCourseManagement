namespace Course.Domain.Entities
{
    using Dapper.Contrib.Extensions;
    using System;

    [Table("[Course]")]
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CrouseShortName { get; set; }
        public int CreditHour { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
