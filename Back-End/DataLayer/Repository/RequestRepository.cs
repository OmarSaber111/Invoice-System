using DataAccessLayer.Repositories;
using DataLayer.Contexts;
using DataLayer.InterFaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataLayer.Repository
{
    public class RequestRepository : Repository<Request>, IRequestRepository
    {
        public RequestRepository(InvoiceDbContext context) : base(context) { }

        public async Task<IEnumerable<Request>> GetAllRequestsAsync()
        {
            return await AsQueryable().ToListAsync();
        }

        public async Task<Request?> GetRequestWithRelationsAsync(int id)
        {
            return await AsQueryable()
                .Include(r => r.RequestRoleForms)
                //.Include(r => r.GroupRoleAuths)
                .FirstOrDefaultAsync(r => r.RequestId == id);
        }
    }
}
