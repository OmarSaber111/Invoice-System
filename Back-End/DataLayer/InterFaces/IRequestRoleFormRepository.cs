using DataAccessLayer.Interfaces;
using Models.Entities;

namespace DataLayer.InterFaces
{
    public interface IRequestRoleFormRepository : IRepository<RequestRoleForm>
    {
        Task<IEnumerable<RequestRoleForm>> GetByRequestIdAsync(int requestId);
        Task<IEnumerable<RequestRoleForm>> GetByRoleIdAsync(int roleId);
        Task<IEnumerable<RequestRoleForm>> GetByFormIdAsync(int formId);
        Task<bool> ExistsAsync(int roleId, int formId, int requestId);
    }
}
