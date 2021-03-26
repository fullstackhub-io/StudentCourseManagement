namespace User.Persistence.UnitOfWork
{
    using System.Data;
    using global::User.Domain.Repositories;
    using global::User.Domain.UnitOfWork;
    using global::User.Persistence.Repositories;

    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection dbConnection;
        private IDbTransaction transaction;
        public UnitOfWork(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            this.ManageConnection();
        }
        public IUserRepository Users => new UserRepository(this.dbConnection, this.transaction);

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
