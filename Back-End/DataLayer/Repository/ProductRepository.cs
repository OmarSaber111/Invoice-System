using DataAccessLayer.Repositories;
using DataLayer.Contexts;
using DataLayer.InterFaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataLayer.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(InvoiceDbContext context) : base(context) { }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await AsQueryable()
                .Include(p => p.Seller)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetBySellerIdAsync(int sellerId)
        {
            return await AsQueryable()
                .Include(p => p.Seller)
                .Where(p => p.SellerId == sellerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await AsQueryable()
                .Include(p => p.Seller)
                .ToListAsync();
        }
    }
}
