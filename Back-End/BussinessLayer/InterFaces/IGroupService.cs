using ApiContract.Dtos;
using ApiContracts;

namespace BussinessLayer.InterFaces
{
    public interface IGroupService
    {
        Task<GResponse<IEnumerable<GroupDto>>> GetAllGroupsAsync();
        Task<GResponse<GroupDto>> GetGroupByIdAsync(int id);
        Task<GResponse<GroupDto>> CreateGroupAsync(CreateGroupDto dto);
        Task<GResponse<string>> UpdateGroupAsync(UpdateGroupDto dto);
        Task<GResponse<bool>> DeleteGroupAsync(int id);
    }
}
