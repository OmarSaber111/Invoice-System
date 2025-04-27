using DataAccessLayer.Interfaces;
using Models.Entities;

namespace DataLayer.InterFaces
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        Task<IEnumerable<Invoice>> GetAllInvoicesAsync();
        Task<Invoice?> GetInvoiceByIdAsync(int id);
        Task<IEnumerable<Invoice>> GetByBuyerIdAsync(int buyerId);
        Task<IEnumerable<Invoice>> GetBySellerIdAsync(int sellerId);
    }
}
