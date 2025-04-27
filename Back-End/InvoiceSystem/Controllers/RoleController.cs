using ApiContract.Dtos;
using BussinessLayer.InterFaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("Get-All-Roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var response = await _roleService.GetAllRolesAsync();
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok(response);
        }

        [HttpGet("GetRoleById/{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var response = await _roleService.GetRoleByIdAsync(id);
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok(response);
        }

        [HttpPost("Create-Role")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto dto)
        {
            var response = await _roleService.CreateRoleAsync(dto);
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok(response);
        }

        [HttpPut("Update-Role")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleDto dto)
        {
            var response = await _roleService.UpdateRoleAsync(dto);
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok(response);
        }

        [HttpDelete("Delete-Role/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var response = await _roleService.DeleteRoleAsync(id);
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok("deleted successfully");
        }
    }
}
