using DataAccessLayer.Repositories;
using DataLayer.Contexts;
using DataLayer.InterFaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataLayer.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(InvoiceDbContext context) : base(context) { }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await AsQueryable()
                 .Include(r => r.RequestRoleForms)
                //.Include(r => r.GroupRoleAuths)
                .ToListAsync();
        }

        public async Task<Role?> GetRoleByIdAsync(int id)
        {
            return await AsQueryable()
                .Include(r => r.RequestRoleForms)
                //.Include(r => r.GroupRoleAuths)
                .FirstOrDefaultAsync(r => r.RoleId == id);
        }
    }
}
