using System.Data;
using StudentCourse.Domain.Repositories;
using StudentCourse.Domain.UnitOfWork;
using StudentCourse.Persistence.Repositories;

namespace StudentCourse.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection dbConnection;
        private IDbTransaction transaction;
        public UnitOfWork(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            this.ManageConnection();
        }
        public IStudentCourseRepository UserCourse => new StudentCourseRepository(this.dbConnection, this.transaction);

        public void StartTransaction()
        {

            if (this.transaction == null)
            {
                this.transaction = this.dbConnection.BeginTransaction();
            }
        }
        public void Commit()
        {
            try
            {
                this.transaction.Commit();
            }
            catch
            {
                this.transaction.Rollback();
            }
        }

        private void ManageConnection()
        {
            if (this.dbConnection.State == ConnectionState.Closed)
            {
                this.dbConnection.Open();
            }
        }
    }
}
