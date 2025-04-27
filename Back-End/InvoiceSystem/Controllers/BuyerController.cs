using ApiContract.Dtos;
using ApiContracts;
using BussinessLayer.InterFaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuyersController : ControllerBase
    {
        private readonly IBuyerService _service;

        public BuyersController(IBuyerService service)
        {
            _service = service;
        }

        [HttpGet("Get-All-Buyers")]
        public async Task<ActionResult<GResponse<IEnumerable<BuyerDto>>>> GetAllBuyers()
        {
            var response = await _service.GetAllBuyersAsync();
            return Ok(response);
        }

        [HttpGet("Get-Buyer-ById/{id}")]
        public async Task<ActionResult<GResponse<BuyerDto>>> GetBuyerById(int id)
        {
            var response = await _service.GetBuyerByIdAsync(id);
            if (!response.IsSucceeded)
                return NotFound(response);
            return Ok(response);
        }
    }

}
