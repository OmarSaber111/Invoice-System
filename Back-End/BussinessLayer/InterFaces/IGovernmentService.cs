using ApiContract.Dtos;
using ApiContracts;

namespace BussinessLayer.InterFaces
{
    public interface IGovernmentService
    {
        Task<GResponse<IEnumerable<GovernmentDto>>> GetAllGovernmentsAsync();
        Task<GResponse<GovernmentDto>> GetGovernmentByIdAsync(int id);
        Task<GResponse<GovernmentDto>> CreateGovernmentAsync(CreateGovernmentDto dto);
        Task<GResponse<string>> UpdateGovernmentAsync(UpdateGovernmentDto dto);
        Task<GResponse<bool>> DeleteGovernmentAsync(int id);
    }

}
