using DataAccessLayer.Repositories;
using DataLayer.Contexts;
using DataLayer.InterFaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataLayer.Repository
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        public AdminRepository(InvoiceDbContext context) : base(context)
        {
        }

        public async Task<Admin> GetAdminByIdAsync(int id)
        {
            var admin = await AsQueryable()
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Id == id);
            return admin;
        }

        public async Task<IEnumerable<Admin>> GetAllAdminsAsync()
        {
            var admins = await AsQueryable()
                .Include(a => a.User)
                .ToListAsync();
            return admins;
        }

        public async Task<Admin?> GetByUsernameWithUserAsync(string username)
        {
            return await AsQueryable()
                .Include(a => a.User)
                .ThenInclude(x => x.GroupUsers)
                .FirstOrDefaultAsync(a => a.Username == username);
        }
        public async Task<Admin?> GetByCredentialsAsync(string username, string password)
        {
            return await AsQueryable()
                .Include(a => a.User)
                    .ThenInclude(u => u.GroupUsers)
                .FirstOrDefaultAsync(a => a.Username == username && a.HashedPassword == password);
        }
        public async Task AddAdminAsync(Admin admin)
        {
            await _context.AddAsync(admin);
            await _context.SaveChangesAsync();
        }
    }
}
