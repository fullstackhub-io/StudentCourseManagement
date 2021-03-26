namespace User.Persistence.Repositories
{
    using Dapper.Contrib.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using User.Domain.Entities;
    using User.Domain.Repositories;

    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(IDbConnection dbConnection, IDbTransaction dbtransaction)
            : base(dbConnection, dbtransaction)
        {
        }
        public Task<int> AddUser(User user)
        {
            user.DateAdded = DateTime.Now;
            user.DateUpdated = null;
            return DbConnection.InsertAsync(user, DbTransaction);
        }

        public Task<bool> DeleteUser(int userId)
        {
            return DbConnection.DeleteAsync(new User { UserID = userId }, DbTransaction);
        }

        public Task<IEnumerable<User>> GetAllUsers()
        {
            return DbConnection.GetAllAsync<User>();
        }

        public Task<User> GetUser(long userId)
        {
            return DbConnection.GetAsync<User>(userId);
        }

        public Task<bool> UpdateUser(User user)
        {
            user.DateUpdated = DateTime.Now;
            return DbConnection.UpdateAsync(user, DbTransaction);
        }

        public Task<bool> DeleteAllUser()
        {
            return DbConnection.DeleteAllAsync<User>();
        }
    }
}
