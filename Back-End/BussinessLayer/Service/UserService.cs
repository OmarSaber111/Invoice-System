using ApiContract.Dtos;
using ApiContracts;
using AutoMapper;
using BussinessLayer.InterFaces;
using DataLayer.InterFaces;

namespace BussinessLayer.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<GResponse<IEnumerable<UserDto>>> GetAllUsersAsync()
        {
            var users = await _userRepo.GetAllUsersAsync();
            var result = _mapper.Map<IEnumerable<UserDto>>(users);
            return GResponse<IEnumerable<UserDto>>.CreateSuccess(result);
        }

        public async Task<GResponse<UserDto>> GetUserByIdAsync(int id)
        {
            var user = await _userRepo.GetUserByIdAsync(id);
            if (user == null)
                return GResponse<UserDto>.CreateFailure("404", "User not found");
            var result = _mapper.Map<UserDto>(user);
            return GResponse<UserDto>.CreateSuccess(result);
        }
        public async Task<GResponse<string>> DeleteUserAsync(int Userid)
        {
            var seller = await _userRepo.GetUserByIdAsync(Userid);
            if (seller == null)
                return GResponse<string>.CreateFailure("404", "user not found");
            _userRepo.Delete(seller);
            await _userRepo.Commit();
            return GResponse<string>.CreateSuccess("deleted successfully");

        }
    }
}
