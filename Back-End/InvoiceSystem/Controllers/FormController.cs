using ApiContract.Dtos;
using BussinessLayer.InterFaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormService _formService;

        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpGet("Get-All-Forms")]
        public async Task<IActionResult> GetAllForms()
        {
            var response = await _formService.GetAllFormsAsync();
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok(response);
        }

        [HttpGet("GetFormById/{id}")]
        public async Task<IActionResult> GetFormById(int id)
        {
            var response = await _formService.GetFormByIdAsync(id);
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok(response);
        }

        [HttpPost("Create-Form")]
        public async Task<IActionResult> CreateForm([FromBody] CreateFormDto dto)
        {
            var response = await _formService.CreateFormAsync(dto);
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok(response);
        }

        [HttpPut("Update-Form")]
        public async Task<IActionResult> UpdateForm([FromBody] UpdateFormDto dto)
        {
            var response = await _formService.UpdateFormAsync(dto);
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok(response);
        }

        [HttpDelete("Delete-Form/{id}")]
        public async Task<IActionResult> DeleteForm(int id)
        {
            var response = await _formService.DeleteFormAsync(id);
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok("deleted successfully");
        }
    }
}
