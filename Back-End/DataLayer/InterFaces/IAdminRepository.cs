using DataAccessLayer.Interfaces;
using Models.Entities;

namespace DataLayer.InterFaces
{
    public interface IAdminRepository : IRepository<Admin>
    {
        Task<Admin?> GetByUsernameWithUserAsync(string username);
        Task<IEnumerable<Admin>> GetAllAdminsAsync();
        Task<Admin> GetAdminByIdAsync(int id);
        Task<Admin> GetByCredentialsAsync(string username, string password);
        Task AddAdminAsync(Admin admin);
    }
}
