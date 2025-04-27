using DataAccessLayer.Repositories;
using DataLayer.Contexts;
using DataLayer.InterFaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataLayer.Repository
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(InvoiceDbContext context) : base(context) { }

        public async Task<IEnumerable<Group>> GetAllGroupsAsync()
        {
            return await AsQueryable()
                .Include(g => g.GroupUsers)
                .Include(g => g.GroupRoleAuths)
                .ToListAsync();
        }

        public async Task<Group?> GetGroupByIdAsync(int id)
        {
            return await AsQueryable()
                .Include(g => g.GroupUsers)
                .Include(g => g.GroupRoleAuths)
                .FirstOrDefaultAsync(g => g.GroupId == id);
        }
    }
}

