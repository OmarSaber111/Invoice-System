using DataAccessLayer.Repositories;
using DataLayer.Contexts;
using DataLayer.InterFaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataLayer.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(InvoiceDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await AsQueryable()
               .Include(a => a.Buyer)
               .Include(a => a.Admin)
               .Include(a => a.Seller)
               .Include(a => a.GroupUsers)
               .ThenInclude(gu => gu.Group)
               .ToListAsync();
            return users;
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            var Username = await AsQueryable()
               .FirstOrDefaultAsync(a => a.Name == username);
            return Username;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await AsQueryable()
               .Include(a => a.Buyer)
               .Include(a => a.Admin)
               .Include(a => a.Seller)
               .Include(a => a.GroupUsers)
               .ThenInclude(gu => gu.Group)
               .FirstOrDefaultAsync(a => a.UserId == id);
            return user;
        }
        public async Task<User?> GetUserByIdWithGroupAsync(int id)
        {
            return await AsQueryable()
                .Include(u => u.GroupUsers)
                    .ThenInclude(gu => gu.Group)
                .FirstOrDefaultAsync(u => u.UserId == id);
        }
        public async Task<User> GetByEmailAsync(string email) =>
        await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
