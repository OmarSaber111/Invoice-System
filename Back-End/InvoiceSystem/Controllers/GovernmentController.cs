using ApiContract.Dtos;
using BussinessLayer.InterFaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernmentController : ControllerBase
    {
        private readonly IGovernmentService _governmentService;

        public GovernmentController(IGovernmentService governmentService)
        {
            _governmentService = governmentService;
        }

        [HttpGet("Get-All-Governments")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _governmentService.GetAllGovernmentsAsync();
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok(response);
        }

        [HttpGet("Get-Government-By-Id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _governmentService.GetGovernmentByIdAsync(id);
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok(response);
        }

        [HttpPost("Create-Government")]
        public async Task<IActionResult> Create([FromBody] CreateGovernmentDto dto)
        {
            var response = await _governmentService.CreateGovernmentAsync(dto);
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok(response);
        }

        [HttpPut("Update-Government")]
        public async Task<IActionResult> Update([FromBody] UpdateGovernmentDto dto)
        {
            var response = await _governmentService.UpdateGovernmentAsync(dto);
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok(response);
        }

        [HttpDelete("Delete-Government/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _governmentService.DeleteGovernmentAsync(id);
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok("deleted successfully");
        }
    }

}
