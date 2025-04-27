using DataAccessLayer.Repositories;
using DataLayer.Contexts;
using DataLayer.InterFaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataLayer.Repository
{
    public class SellerRepository : Repository<Seller>, ISellerRepository
    {
        public SellerRepository(InvoiceDbContext context) : base(context) { }

        public async Task<IEnumerable<Seller>> GetAllSellersAsync()
        {
            return await AsQueryable()
                .Include(s => s.User)
                .Include(s => s.Government)
                .ToListAsync();
        }

        public async Task<Seller?> GetByUsernameWithUserAsync(string username)
        {
            return await AsQueryable()
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.UserName == username);
        }

        public async Task<Seller?> GetSellerByIdAsync(int id)
        {
            return await AsQueryable()
                .Include(s => s.User)
                .Include(s => s.Government)
                .FirstOrDefaultAsync(s => s.SellerId == id);
        }

        public async Task<Seller?> GetSellerWithProductsAsync(int id)
        {
            return await AsQueryable()
                .Include(s => s.Products)
                .FirstOrDefaultAsync(s => s.SellerId == id);
        }

        public async Task<Seller?> GetSellerWithGovernmentAsync(int id)
        {
            return await AsQueryable()
                .Include(s => s.Government)
                .Include(x => x.User)
                .ThenInclude(u => u.GroupUsers)
                .ThenInclude(g => g.Select(x => x.Group))
                .FirstOrDefaultAsync(s => s.SellerId == id);
        }
        public async Task<Seller?> GetByCredentialsAsync(string username, string password)
        {
            return await AsQueryable()
                .Include(s => s.User)
                    .ThenInclude(u => u.GroupUsers)
                .FirstOrDefaultAsync(s => s.UserName == username && s.HashedPassword == password);
        }
        public async Task<Seller?> GetSellerByUserIdAsync(int userId)
        {
            return await AsQueryable()
                .Include(s => s.User)
                .Include(s => s.Government)
                .FirstOrDefaultAsync(s => s.UserId == userId);
        }
    }

}
