using DataAccessLayer.Interfaces;
using Models.Entities;

namespace DataLayer.InterFaces
{
    public interface IGroupUserRepository : IRepository<GroupUser>
    {
        Task<IEnumerable<GroupUser>> GetByGroupIdAsync(int groupId);
        Task<IEnumerable<GroupUser>> GetByUserIdAsync(int userId);
        Task<bool> ExistsAsync(int userId, int groupId);
    }
}
