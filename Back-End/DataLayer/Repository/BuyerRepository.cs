using DataAccessLayer.Repositories;
using DataLayer.Contexts;
using DataLayer.InterFaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataLayer.Repository
{
    public class BuyerRepository : Repository<Buyer>, IBuyerRepository
    {
        public BuyerRepository(InvoiceDbContext context) : base(context) { }

        public async Task<IEnumerable<Buyer>> GetAllBuyersAsync()
        {
            return await AsQueryable()
                .Include(b => b.User)
                .ToListAsync();
        }

        public async Task<Buyer?> GetByUsernameWithUserAsync(string username)
        {
            return await AsQueryable()
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.UserName == username);
        }

        public async Task<Buyer?> GetBuyerByIdAsync(int id)
        {
            return await AsQueryable()
                .Include(b => b.User)
                .FirstOrDefaultAsync(a => a.BuyerId == id);
        }

        public async Task<Buyer?> GetBuyerWithInvoicesAsync(int id)
        {
            return await AsQueryable()
                .Include(b => b.User)
                .Include(b => b.Invoices)
                .FirstOrDefaultAsync(a => a.BuyerId == id);
        }
        public async Task<Buyer?> GetByCredentialsAsync(string username, string password)
        {
            return await AsQueryable()
                .Include(s => s.User)
                    .ThenInclude(u => u.GroupUsers)
                .FirstOrDefaultAsync(s => s.UserName == username && s.HashedPassword == password);
        }
    }
}
