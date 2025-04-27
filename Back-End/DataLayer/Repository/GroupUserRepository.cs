using DataAccessLayer.Repositories;
using DataLayer.Contexts;
using DataLayer.InterFaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataLayer.Repository
{
    public class GroupUserRepository : Repository<GroupUser>, IGroupUserRepository
    {
        public GroupUserRepository(InvoiceDbContext context) : base(context) { }

        public async Task<IEnumerable<GroupUser>> GetByGroupIdAsync(int groupId)
        {
            return await AsQueryable()
                .Where(gu => gu.GroupId == groupId)
                .Include(gu => gu.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<GroupUser>> GetByUserIdAsync(int userId)
        {
            return await AsQueryable()
                .Where(gu => gu.UserId == userId)
                .Include(gu => gu.Group)
                .ToListAsync();
        }
        public async Task<bool> ExistsAsync(int userId, int groupId)
        {
            return await AsQueryable()
                .AnyAsync(gu => gu.UserId == userId && gu.GroupId == groupId);
        }
    }

}
