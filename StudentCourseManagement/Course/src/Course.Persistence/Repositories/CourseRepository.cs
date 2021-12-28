namespace Course.Persistence.Repositories
{
    using Course.Domain.Repositories;
    using Dapper.Contrib.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using CourseEntity = Course.Domain.Entities.Course;

    public class CourseRepository : Repository, ICourseRepository
    {
        public CourseRepository(IDbConnection dbConnection, IDbTransaction dbtransaction)
            : base(dbConnection, dbtransaction)
        {
        }
        public Task<int> AddCourse(CourseEntity course)
        {
            course.DateAdded = DateTime.Now;
            course.DateUpdated = null;
            return DbConnection.InsertAsync(course, DbTransaction);
        }

        public Task<bool> DeleteCourse(int courseId)
        {
            return DbConnection.DeleteAsync(new CourseEntity { CourseID = courseId }, DbTransaction);
        }

        public Task<IEnumerable<CourseEntity>> GetAllCourses()
        {
            return DbConnection.GetAllAsync<CourseEntity>();
        }

        public Task<CourseEntity> GetCourse(long courseId)
        {
            return DbConnection.GetAsync<CourseEntity>(courseId);
        }

        public Task<bool> UpdateCourse(CourseEntity Course)
        {
            Course.DateUpdated = DateTime.Now;
            return DbConnection.UpdateAsync(Course, DbTransaction);
        }

        public Task<bool> DeleteAllCourses()
        {
            return DbConnection.DeleteAllAsync<CourseEntity>();
        }
    }
}
