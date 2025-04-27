using ApiContract.Dtos;
using ApiContracts;
using AutoMapper;
using BussinessLayer.InterFaces;
using DataLayer.InterFaces;
using Models.Entities;

namespace BussinessLayer.Service
{
    public class AdminService : IAdminService
    {
        private readonly IGroupUserRepository _groupUserRepo;
        private readonly IGroupRoleAuthRepository _groupRoleAuthRepo;
        private readonly IRequestRoleFormRepository _requestRoleFormRepo;
        private readonly IUserRepository _userRepo;
        private readonly IAdminRepository _adminRepo;
        private readonly IMapper _mapper;

        public AdminService(
           IGroupUserRepository groupUserRepo,
            IGroupRoleAuthRepository groupRoleAuthRepo,
            IRequestRoleFormRepository requestRoleFormRepo,
            IMapper mapper,
            IUserRepository userRepo,
            IAdminRepository adminRepo)
        {
            _groupUserRepo = groupUserRepo;
            _groupRoleAuthRepo = groupRoleAuthRepo;
            _requestRoleFormRepo = requestRoleFormRepo;
            _mapper = mapper;
            _userRepo = userRepo;
            _adminRepo = adminRepo;
        }

        public async Task<GResponse<string>> AssignUserToGroupAsync(AssignUserToGroupDTO dto)
        {
            if (await _groupUserRepo.ExistsAsync(dto.UserId, dto.GroupId))
                return GResponse<string>.CreateFailure("404", "User already assigned to this group.");

            var groupUser = _mapper.Map<GroupUser>(dto);
            await _groupUserRepo.InsertAsync(groupUser);
            await _groupUserRepo.Commit();

            return GResponse<string>.CreateSuccess("User assigned to group.");
        }

        public async Task<GResponse<string>> AddPermissionToGroupAsync(GroupPermissionDTO dto)
        {
            if (await _groupRoleAuthRepo.ExistsAsync(dto.GroupId, dto.RequestRoleFormId, dto.Action))
                return GResponse<string>.CreateFailure("404", "Permission already exists for this group.");

            var groupRoleAuth = _mapper.Map<GroupRoleAuth>(dto);
            await _groupRoleAuthRepo.InsertAsync(groupRoleAuth);
            await _groupRoleAuthRepo.Commit();

            return GResponse<string>.CreateSuccess("Permission assigned successfully.");
        }

        public async Task<GResponse<string>> AddRequestToRoleFormAsync(RequestRoleFormDTO dto)
        {
            if (await _requestRoleFormRepo.ExistsAsync(dto.RoleId, dto.FormId, dto.RequestId))
                return GResponse<string>.CreateFailure("404", "This request is already assigned to this Role/Form.");

            var requestRoleForm = _mapper.Map<RequestRoleForm>(dto);
            await _requestRoleFormRepo.InsertAsync(requestRoleForm);
            await _requestRoleFormRepo.Commit();

            return GResponse<string>.CreateSuccess("Request added to Role/Form.");
        }

        public async Task<int> CreateAdminAsync(CreateManualAdminDto dto)
        {
            var existingUser = await _userRepo.GetByEmailAsync(dto.Email);
            if (existingUser != null)
                throw new InvalidOperationException("This email is already in use.");

            var user = new User
            {
                Email = dto.Email,
                NationalId = dto.NationalId,
                Name = dto.Name
            };
            await _userRepo.InsertAsync(user);
            await _userRepo.Commit();

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            var admin = new Admin
            {
                UserId = user.UserId,
                Username = dto.Username,
                HashedPassword = hashedPassword
            };
            await _adminRepo.InsertAsync(admin);
            await _adminRepo.Commit();

            return user.UserId;
        }
    }
}
