using ApiContract.Dtos;
using ApiContracts;

namespace BussinessLayer.InterFaces
{
    public interface IFormService
    {
        Task<GResponse<IEnumerable<FormDto>>> GetAllFormsAsync();
        Task<GResponse<FormDto>> GetFormByIdAsync(int id);
        Task<GResponse<FormDto>> CreateFormAsync(CreateFormDto dto);
        Task<GResponse<string>> UpdateFormAsync(UpdateFormDto dto);
        Task<GResponse<bool>> DeleteFormAsync(int id);
    }

}
