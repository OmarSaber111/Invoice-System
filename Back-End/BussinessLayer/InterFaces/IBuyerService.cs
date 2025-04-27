using ApiContract.Dtos;
using ApiContracts;

namespace BussinessLayer.InterFaces
{
    public interface IBuyerService
    {
        Task<GResponse<IEnumerable<BuyerDto>>> GetAllBuyersAsync();
        Task<GResponse<BuyerDto>> GetBuyerByIdAsync(int id);
    }
}
