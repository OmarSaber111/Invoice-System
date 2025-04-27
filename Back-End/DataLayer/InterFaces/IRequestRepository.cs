using DataAccessLayer.Interfaces;
using Models.Entities;

namespace DataLayer.InterFaces
{
    public interface IRequestRepository : IRepository<Request>
    {
        Task<Request?> GetRequestWithRelationsAsync(int id);
        Task<IEnumerable<Request>> GetAllRequestsAsync();
    }
}
