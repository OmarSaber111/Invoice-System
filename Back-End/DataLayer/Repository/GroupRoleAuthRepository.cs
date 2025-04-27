using DataAccessLayer.Repositories;
using DataLayer.Contexts;
using DataLayer.InterFaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataLayer.Repository
{
    public class GroupRoleAuthRepository : Repository<GroupRoleAuth>, IGroupRoleAuthRepository
    {
        public GroupRoleAuthRepository(InvoiceDbContext context) : base(context) { }

        public async Task<GroupRoleAuth?> GetGroupRoleAuthByIdAsync(int id)
        {
            return await AsQueryable()
                .Include(gra => gra.Group)
                .Include(gra => gra.RequestRoleForm)
                .FirstOrDefaultAsync(gra => gra.Id == id);
        }

        public async Task<IEnumerable<GroupRoleAuth>> GetByGroupIdAsync(int groupId)
        {
            return await AsQueryable()
                .Where(gra => gra.GroupId == groupId)
                .ToListAsync();
        }
        public async Task<bool> ExistsAsync(int groupId, int requestroleformid, string action)
        {
            return await AsQueryable()
                .AnyAsync(g => g.RequestRoleFormId == requestroleformid
                             && g.GroupId == groupId &&
                              g.Action == action);
        }
    }
}
