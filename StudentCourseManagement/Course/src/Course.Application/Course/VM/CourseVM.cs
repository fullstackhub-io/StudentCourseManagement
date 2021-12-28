namespace Course.Application.Course.VM
{
    using global::Course.Application.Course.DTO;
    using System.Collections.Generic;
    public class CourseVM
    {
        public IList<CourseDTO> CourseList { get; set; }
    }
}
