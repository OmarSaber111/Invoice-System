using ApiContract.Dtos;
using ApiContracts;

namespace BussinessLayer.InterFaces
{
    public interface IRoleService
    {
        Task<GResponse<IEnumerable<RoleDto>>> GetAllRolesAsync();
        Task<GResponse<RoleDto>> GetRoleByIdAsync(int id);
        Task<GResponse<RoleDto>> CreateRoleAsync(CreateRoleDto dto);
        Task<GResponse<string>> UpdateRoleAsync(UpdateRoleDto dto);
        Task<GResponse<bool>> DeleteRoleAsync(int id);
    }
}
