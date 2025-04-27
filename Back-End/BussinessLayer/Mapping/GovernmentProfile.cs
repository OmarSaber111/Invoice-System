using ApiContract.Dtos;
using AutoMapper;
using Models.Entities;

namespace BussinessLayer.Mapping
{
    class GovernmentProfile : Profile
    {
        public GovernmentProfile()
        {
            CreateMap<Government, GovernmentDto>();
            CreateMap<CreateGovernmentDto, Government>();
            CreateMap<UpdateGovernmentDto, Government>();
        }
    }
}
