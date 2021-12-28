namespace Course.Persistence.Repositories
{
    using System.Data;
    public class Repository
    {
        protected IDbConnection DbConnection { get; }
        protected IDbTransaction DbTransaction { get; }
        public Repository(IDbConnection dbConnection, IDbTransaction dbTransaction)
        {
            DbTransaction = dbTransaction;
            DbConnection = dbConnection;
        }
    }
}
