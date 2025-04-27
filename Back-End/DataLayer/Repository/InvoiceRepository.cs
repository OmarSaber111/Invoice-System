using DataAccessLayer.Repositories;
using DataLayer.Contexts;
using DataLayer.InterFaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataLayer.Repository
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(InvoiceDbContext context) : base(context) { }

        public async Task<Invoice?> GetInvoiceByIdAsync(int id)
        {
            return await AsQueryable()
                .Include(i => i.Buyer)
                .Include(i => i.Seller)
                .Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Invoice>> GetByBuyerIdAsync(int buyerId)
        {
            return await AsQueryable()
                .Where(i => i.BuyerId == buyerId)
                .Include(i => i.Product)
                .Include(i => i.Seller)
                .ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> GetBySellerIdAsync(int sellerId)
        {
            return await AsQueryable()
                .Where(i => i.SellerId == sellerId)
                .Include(i => i.Product)
                .Include(i => i.Buyer)
                .ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
        {
            return await AsQueryable()
                .Include(i => i.Buyer)
                .Include(i => i.Seller)
                .Include(i => i.Product)
                .ToListAsync();
        }
    }
}
