using DataAccessLayer.Interfaces;
using Models.Entities;

namespace DataLayer.InterFaces
{
    public interface ISellerRepository : IRepository<Seller>
    {
        Task<Seller> GetByUsernameWithUserAsync(string username);
        Task<IEnumerable<Seller>> GetAllSellersAsync();
        Task<Seller?> GetSellerByIdAsync(int id);
        Task<Seller?> GetSellerWithProductsAsync(int id);
        Task<Seller?> GetSellerWithGovernmentAsync(int id);
        Task<Seller?> GetByCredentialsAsync(string username, string password);
        Task<Seller?> GetSellerByUserIdAsync(int userId);
    }
}
