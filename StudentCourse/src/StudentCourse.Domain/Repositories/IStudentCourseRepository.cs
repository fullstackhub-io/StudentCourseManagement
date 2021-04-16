using System.Collections.Generic;
using System.Threading.Tasks;
namespace StudentCourse.Domain.Repositories
{
    using StudentCourseEntity = StudentCourse.Domain.Entities.StudentCourse;
    public interface IStudentCourseRepository
    {
        Task<int> AddStudentCourse(StudentCourseEntity course);
        Task<bool> UpdateStudentCourse(StudentCourseEntity course);
        Task<bool> DeleteStudentCourse(int courseId);
        Task<IEnumerable<StudentCourseEntity>> GetAllStudentCourse();
        Task<StudentCourseEntity> GetStudentCourse(long studentCourseId);
        Task<bool> DeleteAllStudentCourse();
    }
}
