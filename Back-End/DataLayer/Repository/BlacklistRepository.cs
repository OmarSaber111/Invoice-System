using DataAccessLayer.Repositories;
using DataLayer.Contexts;
using DataLayer.InterFaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataLayer.Repository
{
    public class BlacklistRepository : Repository<BlackListedTokens>, IBlacklistRepository
    {
        public BlacklistRepository(InvoiceDbContext context) : base(context)
        {
        }

        public async Task AddAsync(BlackListedTokens token)
        {
            await _context.AddAsync(token);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsBlacklistedAsync(string token)
        {
            return await AsQueryable().Where(t => t.Token == token).AnyAsync();
        }
    }
}
