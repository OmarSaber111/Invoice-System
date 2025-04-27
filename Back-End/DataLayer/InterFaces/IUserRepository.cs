using DataAccessLayer.Interfaces;
using Models.Entities;

namespace DataLayer.InterFaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User?> GetUserByIdWithGroupAsync(int id);
        Task<User> GetByEmailAsync(string email);
        Task AddUserAsync(User user);
    }
}
