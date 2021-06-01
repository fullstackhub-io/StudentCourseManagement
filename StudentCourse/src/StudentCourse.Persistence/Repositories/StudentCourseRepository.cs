namespace StudentCourse.Persistence.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using Dapper.Contrib.Extensions;
    using StudentCourse.Domain.Entities;
    using StudentCourse.Domain.Repositories;

    public class StudentCourseRepository : Repository, IStudentCourseRepository
    {
        public StudentCourseRepository(IDbConnection dbConnection, IDbTransaction dbtransaction)
           : base(dbConnection, dbtransaction)
        {
        }

        public Task<int> AddStudentCourse(StudentCourse course)
        {
            course.DateAdded = DateTime.Now;
            course.DateUpdated = null;
            return DbConnection.InsertAsync(course, DbTransaction);
        }

        public Task<bool> DeleteAllStudentCourse()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteStudentCourse(int courseId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<StudentCourse>> GetAllStudentCourse()
        {
            return DbConnection.GetAllAsync<StudentCourse>();
        }

        public Task<StudentCourse> GetStudentCourse(long courseId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateStudentCourse(StudentCourse course)
        {
            throw new System.NotImplementedException();
        }
    }
}
