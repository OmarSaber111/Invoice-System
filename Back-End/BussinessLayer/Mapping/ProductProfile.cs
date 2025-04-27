using ApiContract.Dtos;
using AutoMapper;
using Models.Entities;

namespace BussinessLayer.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.SellerName, opt => opt.MapFrom(src => src.Seller.UserName));

            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
        }
    }
}
