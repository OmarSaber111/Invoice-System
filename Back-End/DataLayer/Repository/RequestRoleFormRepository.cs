using DataAccessLayer.Repositories;
using DataLayer.Contexts;
using DataLayer.InterFaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataLayer.Repository
{
    public class RequestRoleFormRepository : Repository<RequestRoleForm>, IRequestRoleFormRepository
    {
        public RequestRoleFormRepository(InvoiceDbContext context) : base(context) { }

        public async Task<IEnumerable<RequestRoleForm>> GetByRequestIdAsync(int requestId)
        {
            return await AsQueryable()
                .Where(rrf => rrf.RequestId == requestId)
                .Include(rrf => rrf.Role)
                .Include(rrf => rrf.Form)
                .ToListAsync();
        }

        public async Task<IEnumerable<RequestRoleForm>> GetByRoleIdAsync(int roleId)
        {
            return await AsQueryable()
                .Where(rrf => rrf.RoleId == roleId)
                .Include(rrf => rrf.Request)
                .Include(rrf => rrf.Form)
                .ToListAsync();
        }

        public async Task<IEnumerable<RequestRoleForm>> GetByFormIdAsync(int formId)
        {
            return await AsQueryable()
                .Where(rrf => rrf.FormId == formId)
                .Include(rrf => rrf.Request)
                .Include(rrf => rrf.Role)
                .ToListAsync();
        }
        public async Task<bool> ExistsAsync(int roleId, int formId, int requestId)
        {
            return await AsQueryable()
                .AnyAsync(r => r.RoleId == roleId &&
                             r.FormId == formId &&
                             r.RequestId == requestId);
        }
    }
}
