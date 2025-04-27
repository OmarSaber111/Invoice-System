using ApiContract.Dtos;
using ApiContracts;
using AutoMapper;
using BussinessLayer.InterFaces;
using DataLayer.InterFaces;
using Models.Entities;

namespace BussinessLayer.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepo;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepo, IMapper mapper)
        {
            _roleRepo = roleRepo;
            _mapper = mapper;
        }

        public async Task<GResponse<IEnumerable<RoleDto>>> GetAllRolesAsync()
        {
            var roles = await _roleRepo.GetAllRolesAsync();
            var result = _mapper.Map<IEnumerable<RoleDto>>(roles);
            return GResponse<IEnumerable<RoleDto>>.CreateSuccess(result);
        }

        public async Task<GResponse<RoleDto>> GetRoleByIdAsync(int id)
        {
            var role = await _roleRepo.GetRoleByIdAsync(id);
            if (role == null)
                return GResponse<RoleDto>.CreateFailure("404", "Role not found");

            var result = _mapper.Map<RoleDto>(role);
            return GResponse<RoleDto>.CreateSuccess(result);
        }

        public async Task<GResponse<RoleDto>> CreateRoleAsync(CreateRoleDto dto)
        {
            var role = _mapper.Map<Role>(dto);
            await _roleRepo.InsertAsync(role);
            await _roleRepo.Commit();

            var result = _mapper.Map<RoleDto>(role);
            return GResponse<RoleDto>.CreateSuccess(result);
        }

        public async Task<GResponse<string>> UpdateRoleAsync(UpdateRoleDto dto)
        {
            var role = await _roleRepo.GetRoleByIdAsync(dto.RoleId);
            if (role == null)
                return GResponse<string>.CreateFailure("404", "Role not found");

            _mapper.Map(dto, role);
            await _roleRepo.Commit();

            return GResponse<string>.CreateSuccess("Role updated successfully.");
        }

        public async Task<GResponse<bool>> DeleteRoleAsync(int id)
        {
            var role = await _roleRepo.GetRoleByIdAsync(id);
            if (role == null)
                return GResponse<bool>.CreateFailure("404", "Role not found");

            _roleRepo.Delete(role);
            await _roleRepo.Commit();

            return GResponse<bool>.CreateSuccess(true);
        }
    }
}
