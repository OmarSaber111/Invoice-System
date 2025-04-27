using DataAccessLayer.Interfaces;
using Models.Entities;


namespace DataLayer.InterFaces
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<Group?> GetGroupByIdAsync(int id);
        Task<IEnumerable<Group>> GetAllGroupsAsync();
    }
}
