using DataAccessLayer.Interfaces;
using Models.Entities;

namespace DataLayer.InterFaces
{
    public interface IFormRepository : IRepository<Form>
    {
        Task<Form?> GetFormByIdAsync(int id);
        Task<IEnumerable<Form>> GetAllFormsAsync();

    }
}
