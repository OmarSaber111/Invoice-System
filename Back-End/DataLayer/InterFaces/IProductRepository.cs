using DataAccessLayer.Interfaces;
using Models.Entities;

namespace DataLayer.InterFaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product?> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetBySellerIdAsync(int sellerId);
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
