using ApiContract.Dtos;
using ApiContracts;
using BussinessLayer.InterFaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellersController : ControllerBase
    {
        private readonly ISellerService _service;

        public SellersController(ISellerService service)
        {
            _service = service;
        }

        [HttpGet("Get-All-Sellers")]
        public async Task<ActionResult<GResponse<IEnumerable<SellerDto>>>> GetAllSellers()
        {
            var response = await _service.GetAllSellersAsync();
            return Ok(response);
        }

        [HttpGet("Get-Seller-ById/{id}")]
        public async Task<ActionResult<GResponse<SellerDto>>> GetSellerById(int id)
        {
            var response = await _service.GetSellerByIdAsync(id);
            if (!response.IsSucceeded)
                return NotFound(response);
            return Ok(response);
        }
        [HttpGet("Get-Seller-ByUserId/{userId}")]
        public async Task<ActionResult<SellerDto>> GetSellerByUserId(int userId)
        {
            var seller = await _service.GetSellerByUserIdAsync(userId);
            if (seller == null)
                return NotFound($"No seller found for user ID {userId}");

            return Ok(seller);
        }
        [HttpPut("Update-Seller")]
        public async Task<ActionResult<SellerDto>> UpdateSeller(UpdateSellerDto updateSellerDto)
        {
            var result = await _service.UpdateSellerAsync(updateSellerDto);
            if (!result.IsSucceeded)
                return BadRequest($"failed to update");

            return Ok("updated successfully");
        }
        [HttpDelete("Delete-Seller")]
        public async Task<ActionResult<SellerDto>> DeleteSeller(int sellerid)
        {
            var result = await _service.DeleteSellerAsync(sellerid);
            if (!result.IsSucceeded)
                return BadRequest($"failed to delete");

            return Ok("deleted successfully");
        }

    }
}
