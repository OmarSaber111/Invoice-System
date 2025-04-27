using ApiContract.Dtos;
using AutoMapper;
using Models.Entities;

namespace BussinessLayer.Mapping
{
    public class BuyerProfile : Profile
    {
        public BuyerProfile()
        {
            CreateMap<Buyer, BuyerDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(des => des.Id, opt => opt.MapFrom(des => des.BuyerId));
        }
    }
}
