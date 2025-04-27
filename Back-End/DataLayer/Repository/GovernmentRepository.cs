using DataAccessLayer.Repositories;
using DataLayer.Contexts;
using DataLayer.InterFaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataLayer.Repository
{
    public class GovernmentRepository : Repository<Government>, IGovernmentRepository
    {
        public GovernmentRepository(InvoiceDbContext context) : base(context) { }

        public async Task<IEnumerable<Government>> GetAllGovernmentsAsync()
        {
            return await AsQueryable().ToListAsync();
        }

        public async Task<Government?> GetGovernmentByIdAsync(int id)
        {
            return await AsQueryable()
                .Include(g => g.Sellers)
                .FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}
