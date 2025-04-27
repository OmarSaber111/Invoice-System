using DataAccessLayer.Interfaces;
using Models.Entities;

namespace DataLayer.InterFaces
{
    public interface IBuyerRepository : IRepository<Buyer>
    {
        Task<Buyer> GetByUsernameWithUserAsync(string username);
        Task<IEnumerable<Buyer>> GetAllBuyersAsync();
        Task<Buyer?> GetBuyerByIdAsync(int id);
        Task<Buyer?> GetBuyerWithInvoicesAsync(int id);
        Task<Buyer?> GetByCredentialsAsync(string username, string password);
    }
}
