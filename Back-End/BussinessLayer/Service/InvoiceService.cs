using ApiContract.Dtos;
using ApiContracts;
using AutoMapper;
using BussinessLayer.InterFaces;
using DataLayer.InterFaces;
using Models.Entities;

namespace BussinessLayer.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepo;
        private readonly IMapper _mapper;

        public InvoiceService(IInvoiceRepository invoiceRepo, IMapper mapper)
        {
            _invoiceRepo = invoiceRepo;
            _mapper = mapper;
        }

        public async Task<GResponse<IEnumerable<InvoiceDto>>> GetAllInvoicesAsync()
        {
            var invoices = await _invoiceRepo.GetAllInvoicesAsync();
            var result = _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
            return GResponse<IEnumerable<InvoiceDto>>.CreateSuccess(result);
        }

        public async Task<GResponse<InvoiceDto>> GetInvoiceByIdAsync(int id)
        {
            var invoice = await _invoiceRepo.GetInvoiceByIdAsync(id);
            if (invoice == null)
                return GResponse<InvoiceDto>.CreateFailure("404", "Invoice not found");

            var result = _mapper.Map<InvoiceDto>(invoice);
            return GResponse<InvoiceDto>.CreateSuccess(result);
        }

        public async Task<GResponse<InvoiceDto>> CreateInvoiceAsync(CreateInvoiceDto dto)
        {
            var invoice = _mapper.Map<Invoice>(dto);
            await _invoiceRepo.InsertAsync(invoice);
            await _invoiceRepo.Commit();
            var result = _mapper.Map<InvoiceDto>(invoice);
            return GResponse<InvoiceDto>.CreateSuccess(result);
        }

        public async Task<GResponse<string>> UpdateInvoiceAsync(UpdateInvoiceDto dto)
        {
            var invoice = await _invoiceRepo.GetInvoiceByIdAsync(dto.Id);
            if (invoice == null)
                return GResponse<string>.CreateFailure("404", "Invoice not found");

            _mapper.Map(dto, invoice);
            await _invoiceRepo.Commit();
            return GResponse<string>.CreateSuccess("Invoice updated successfully.");
        }

        public async Task<GResponse<bool>> DeleteInvoiceAsync(int id)
        {
            var invoice = await _invoiceRepo.GetInvoiceByIdAsync(id);
            if (invoice == null)
                return GResponse<bool>.CreateFailure("404", "Invoice not found");

            _invoiceRepo.Delete(invoice);
            await _invoiceRepo.Commit();
            return GResponse<bool>.CreateSuccess(true);
        }

        public async Task<GResponse<IEnumerable<InvoiceDto>>> GetInvoiceBySellerIdAsync(int sellerid)
        {
            var invoices = await _invoiceRepo.GetBySellerIdAsync(sellerid);
            if (invoices == null)
                return GResponse<IEnumerable<InvoiceDto>>.CreateFailure("404", "Invoice not found for this seller");

            var result = _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
            return GResponse<IEnumerable<InvoiceDto>>.CreateSuccess(result);
        }

        public async Task<GResponse<IEnumerable<InvoiceDto>>> GetInvoiceByBuyerIdAsync(int buyerid)
        {
            var invoices = await _invoiceRepo.GetByBuyerIdAsync(buyerid);
            if (invoices == null)
                return GResponse<IEnumerable<InvoiceDto>>.CreateFailure("404", "Invoice not found for this buyer");

            var result = _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
            return GResponse<IEnumerable<InvoiceDto>>.CreateSuccess(result);
        }
    }

}
