using DataAccessLayer.Interfaces;
using Models.Entities;

namespace DataLayer.InterFaces
{
    public interface IGovernmentRepository : IRepository<Government>
    {
        Task<Government?> GetGovernmentByIdAsync(int id);
        Task<IEnumerable<Government>> GetAllGovernmentsAsync();
    }
}
