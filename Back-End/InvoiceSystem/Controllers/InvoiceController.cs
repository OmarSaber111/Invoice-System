using ApiContract.Dtos;
using BussinessLayer.InterFaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("Get-All-Invoices")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _invoiceService.GetAllInvoicesAsync();
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok(response);
        }

        [HttpGet("GetInvoiceById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _invoiceService.GetInvoiceByIdAsync(id);
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok(response);
        }

        [HttpPost("Create-Invoice")]
        public async Task<IActionResult> Create([FromBody] CreateInvoiceDto dto)
        {
            var response = await _invoiceService.CreateInvoiceAsync(dto);
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok(response);
        }

        [HttpPut("Update-Invoice")]
        public async Task<IActionResult> Update([FromBody] UpdateInvoiceDto dto)
        {
            var response = await _invoiceService.UpdateInvoiceAsync(dto);
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok(response);
        }

        [HttpDelete("Delete-Invoice/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _invoiceService.DeleteInvoiceAsync(id);
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok("deleted successfully");
        }
        [HttpGet("Get-Invoice-BySellerId/{sellerid}")]
        public async Task<IActionResult> GetInvoiceBySellerId(int sellerid)
        {
            var response = await _invoiceService.GetInvoiceBySellerIdAsync(sellerid);
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok(response);
        }
        [HttpGet("Get-Invoice-ByBuyerId/{buyerid}")]
        public async Task<IActionResult> GetInvoiceByBuyerId(int buyerid)
        {
            var response = await _invoiceService.GetInvoiceByBuyerIdAsync(buyerid);
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok(response);
        }
    }

}
