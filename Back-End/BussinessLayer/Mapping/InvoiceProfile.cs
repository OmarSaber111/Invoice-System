using ApiContract.Dtos;
using AutoMapper;
using Models.Entities;

namespace BussinessLayer.Mapping
{
    class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<CreateInvoiceDto, Invoice>();
            CreateMap<UpdateInvoiceDto, Invoice>();
        }
    }
}
