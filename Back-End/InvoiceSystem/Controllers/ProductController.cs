using ApiContract.Dtos;
using ApiContracts;
using BussinessLayer.InterFaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("Get-All-Products")]
        public async Task<IActionResult> GetAll()
        {
            var res = await _service.GetAllProductsAsync();
            if (!res.IsSucceeded)
                return BadRequest(res.ErrorMessage);
            return Ok(res);
        }

        [HttpGet("Get-Product-ById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _service.GetProductByIdAsync(id);
            if (!res.IsSucceeded)
                return BadRequest(res.ErrorMessage);
            return Ok(res);
        }

        [HttpPost("Create-Product")]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            var res = await _service.CreateProductAsync(dto);
            if (!res.IsSucceeded)
                return BadRequest(res.ErrorMessage);
            return Ok(res);
        }

        [HttpPut("Update-Product")]
        public async Task<IActionResult> Update([FromBody] UpdateProductDto dto)
        {
            var res = await _service.UpdateProductAsync(dto);
            if (!res.IsSucceeded)
                return BadRequest(res.ErrorMessage);
            return Ok(res);
        }

        [HttpDelete("Delete-Product/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _service.DeleteProductAsync(id);
            if (!res.IsSucceeded)
                return BadRequest(res.ErrorMessage);
            return Ok(res);
        }
        [HttpGet("Get-All-Products-BySellerId/{sellerId}")]
        public async Task<ActionResult<GResponse<IEnumerable<ProductDto>>>> GetAllProductsBySellerAsync(int sellerId)
        {
            var response = await _service.GetAllProductsBySellerIfAsync(sellerId);

            if (!response.IsSucceeded)
                return NotFound(response);
            return Ok(response);
        }
    }

}
