using ApiContract.Dtos;
using ApiContracts;

namespace BussinessLayer.InterFaces
{
    public interface ISellerService
    {
        Task<GResponse<IEnumerable<SellerDto>>> GetAllSellersAsync();
        Task<GResponse<SellerDto>> GetSellerByIdAsync(int id);
        Task<GResponse<SellerDto>> GetSellerByUserIdAsync(int userId);
        Task<GResponse<bool>> UpdateSellerAsync(UpdateSellerDto updateSellerDto);
        Task<GResponse<bool>> DeleteSellerAsync(int sellerid);
    }
}
