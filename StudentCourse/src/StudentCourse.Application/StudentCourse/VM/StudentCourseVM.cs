using System.Collections.Generic;
using StudentCourse.Application.StudentCourse.DTO;

namespace StudentCourse.Application.StudentCourse.VM
{
    public class StudentCourseVM
    {
        public IList<StudentCourseDTO> CourseList { get; set; }
    }
}
