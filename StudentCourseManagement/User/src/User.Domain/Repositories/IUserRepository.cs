namespace User.Domain.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using User.Domain.Entities;

    public interface IUserRepository
    {
        Task<int> AddUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int userId);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUser(long userId);
        Task<bool> DeleteAllUser();
    }
}
