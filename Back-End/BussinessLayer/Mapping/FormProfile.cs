using ApiContract.Dtos;
using AutoMapper;
using Models.Entities;

namespace BussinessLayer.Mapping
{
    class FormProfile : Profile
    {
        public FormProfile()
        {
            CreateMap<Form, FormDto>().ReverseMap();
            CreateMap<CreateFormDto, Form>();
            CreateMap<UpdateFormDto, Form>();
        }
    }
}
