using DataAccessLayer.Interfaces;
using Models.Entities;

namespace DataLayer.InterFaces
{
    public interface IGroupRoleAuthRepository : IRepository<GroupRoleAuth>
    {
        Task<GroupRoleAuth?> GetGroupRoleAuthByIdAsync(int id);
        Task<IEnumerable<GroupRoleAuth>> GetByGroupIdAsync(int groupId);
        Task<bool> ExistsAsync(int groupId, int requestroleformid, string action);
    }
}
