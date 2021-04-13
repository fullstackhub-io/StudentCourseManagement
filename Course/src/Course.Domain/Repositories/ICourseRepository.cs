namespace Course.Domain.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Course.Domain.Entities;

    public interface ICourseRepository
    {
        Task<int> AddCourse(Course course);
        Task<bool> UpdateCourse(Course course);
        Task<bool> DeleteCourse(int courseId);
        Task<IEnumerable<Course>> GetAllCourses();
        Task<Course> GetCourse(long courseId);
        Task<bool> DeleteAllCourses();
    }
}
