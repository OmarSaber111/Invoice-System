using ApiContract.Dtos;
using AutoMapper;
using Models.Entities;

namespace BussinessLayer.Mapping
{
    class RoleProfile : Profile

    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDto>();
            CreateMap<CreateRoleDto, Role>();
            CreateMap<UpdateRoleDto, Role>();
        }
    }
}
