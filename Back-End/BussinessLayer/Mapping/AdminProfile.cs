using ApiContract.Dtos;
using AutoMapper;
using Models.Entities;

namespace BussinessLayer.Mapping
{
    class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<Admin, AdminDto>().ReverseMap();
            CreateMap<AssignUserToGroupDTO, GroupUser>();
            CreateMap<GroupPermissionDTO, GroupRoleAuth>();
            CreateMap<RequestRoleFormDTO, RequestRoleForm>();
        }
    }
}
