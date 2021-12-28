using StudentCourse.Domain.Repositories;

namespace StudentCourse.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IStudentCourseRepository UserCourse { get; }
        void StartTransaction();
        void Commit();
    }
}
