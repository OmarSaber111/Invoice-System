using ApiContract.Dtos;
using AutoMapper;
using Models.Entities;

namespace BussinessLayer.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Group, opt => opt.MapFrom(src =>
                    src.GroupUsers != null && src.GroupUsers.Any() && src.GroupUsers.FirstOrDefault().Group != null
                        ? src.GroupUsers.FirstOrDefault().Group.GroupName
                        : "Not assigned to Group"));
        }

    }
}
