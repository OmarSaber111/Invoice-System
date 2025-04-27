using ApiContract.Dtos;
using ApiContracts;

namespace BussinessLayer.InterFaces
{
    public interface IAuthService
    {
        Task<GResponse<string>> SignUpAsync(SignUpDTO dto);
        Task<GResponse<LoginResponseDto>> LoginAsync(LoginDto loginDto);
        Task SignOutAsync(string token);

    }
}
