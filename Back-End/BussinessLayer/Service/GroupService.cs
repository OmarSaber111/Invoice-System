using ApiContract.Dtos;
using ApiContracts;
using AutoMapper;
using BussinessLayer.InterFaces;
using DataLayer.InterFaces;
using Models.Entities;

namespace BussinessLayer.Service
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepo;
        private readonly IMapper _mapper;

        public GroupService(IGroupRepository groupRepo, IMapper mapper)
        {
            _groupRepo = groupRepo;
            _mapper = mapper;
        }

        public async Task<GResponse<IEnumerable<GroupDto>>> GetAllGroupsAsync()
        {
            var groups = await _groupRepo.GetAllGroupsAsync();
            var result = _mapper.Map<IEnumerable<GroupDto>>(groups);
            return GResponse<IEnumerable<GroupDto>>.CreateSuccess(result);
        }

        public async Task<GResponse<GroupDto>> GetGroupByIdAsync(int id)
        {
            var group = await _groupRepo.GetGroupByIdAsync(id);
            if (group == null)
                return GResponse<GroupDto>.CreateFailure("404", "Group not found");

            var result = _mapper.Map<GroupDto>(group);
            return GResponse<GroupDto>.CreateSuccess(result);
        }

        public async Task<GResponse<GroupDto>> CreateGroupAsync(CreateGroupDto dto)
        {
            var group = _mapper.Map<Group>(dto);
            await _groupRepo.InsertAsync(group);
            await _groupRepo.Commit();

            var result = _mapper.Map<GroupDto>(group);
            return GResponse<GroupDto>.CreateSuccess(result);
        }

        public async Task<GResponse<string>> UpdateGroupAsync(UpdateGroupDto dto)
        {
            var group = await _groupRepo.GetGroupByIdAsync(dto.GroupId);
            if (group == null)
                return GResponse<string>.CreateFailure("404", "Group not found");

            _mapper.Map(dto, group);
            await _groupRepo.Commit();

            return GResponse<string>.CreateSuccess("Group updated successfully.");
        }

        public async Task<GResponse<bool>> DeleteGroupAsync(int id)
        {
            var group = await _groupRepo.GetGroupByIdAsync(id);
            if (group == null)
                return GResponse<bool>.CreateFailure("404", "Group not found");

            _groupRepo.Delete(group);
            await _groupRepo.Commit();

            return GResponse<bool>.CreateSuccess(true);
        }
    }
}

