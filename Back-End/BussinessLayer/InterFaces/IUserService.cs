using ApiContract.Dtos;
using ApiContracts;

namespace BussinessLayer.InterFaces
{
    public interface IUserService
    {
        Task<GResponse<IEnumerable<UserDto>>> GetAllUsersAsync();
        Task<GResponse<UserDto>> GetUserByIdAsync(int id);
        Task<GResponse<string>> DeleteUserAsync(int Userid);
    }
}
