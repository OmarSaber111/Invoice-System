using ApiContract.Dtos;
using ApiContracts;

namespace BussinessLayer.InterFaces
{
    public interface IInvoiceService
    {
        Task<GResponse<IEnumerable<InvoiceDto>>> GetAllInvoicesAsync();
        Task<GResponse<InvoiceDto>> GetInvoiceByIdAsync(int id);
        Task<GResponse<IEnumerable<InvoiceDto>>> GetInvoiceBySellerIdAsync(int sellerid);
        Task<GResponse<IEnumerable<InvoiceDto>>> GetInvoiceByBuyerIdAsync(int buyerid);

        Task<GResponse<InvoiceDto>> CreateInvoiceAsync(CreateInvoiceDto dto);
        Task<GResponse<string>> UpdateInvoiceAsync(UpdateInvoiceDto dto);
        Task<GResponse<bool>> DeleteInvoiceAsync(int id);
    }

}
