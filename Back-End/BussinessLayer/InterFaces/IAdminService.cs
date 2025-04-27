using ApiContract.Dtos;
using ApiContracts;

namespace BussinessLayer.InterFaces
{
    public interface IAdminService
    {
        Task<GResponse<string>> AssignUserToGroupAsync(AssignUserToGroupDTO dto);
        Task<GResponse<string>> AddPermissionToGroupAsync(GroupPermissionDTO dto);
        Task<GResponse<string>> AddRequestToRoleFormAsync(RequestRoleFormDTO dto);
        Task<int> CreateAdminAsync(CreateManualAdminDto dto);
    }

}
