namespace Course.Persistence.UnitOfWork
{
    using global::Course.Domain.Repositories;
    using global::Course.Domain.UnitOfWork;
    using global::Course.Persistence.Repositories;
    using System.Data;

    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection dbConnection;
        private IDbTransaction transaction;
        public UnitOfWork(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            this.ManageConnection();
        }
        public ICourseRepository Users => new CourseRepository(this.dbConnection, this.transaction);

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
