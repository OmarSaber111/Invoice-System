using ApiContract.Dtos;
using BussinessLayer.InterFaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("Assign-User-to-Group")]
        public async Task<IActionResult> AssignUserToGroup([FromBody] AssignUserToGroupDTO dto)
        {
            var result = await _adminService.AssignUserToGroupAsync(dto);
            if (!result.IsSucceeded)
                return BadRequest(result.ErrorMessage ?? "the operation failed");

            return Ok(result);
        }

        [HttpPost("Add-Permission-to-Group")]
        public async Task<IActionResult> AddPermissionToGroup([FromBody] GroupPermissionDTO dto)
        {
            var result = await _adminService.AddPermissionToGroupAsync(dto);
            if (!result.IsSucceeded)
                return BadRequest(result.ErrorMessage ?? "the operation failed");

            return Ok(result);
        }

        [HttpPost("Add-Request-to-Role-Form")]
        public async Task<IActionResult> AddRequestToRoleForm([FromBody] RequestRoleFormDTO dto)
        {
            var result = await _adminService.AddRequestToRoleFormAsync(dto);
            if (!result.IsSucceeded)
                return BadRequest(result.ErrorMessage ?? "the operation failed");

            return Ok(result);
        }
        [HttpPost("Create-Admin")]
        public async Task<IActionResult> CreateAdmin([FromBody] CreateManualAdminDto dto)
        {
            var result = await _adminService.CreateAdminAsync(dto);
            if (result == 0) return BadRequest(result);

            return Ok(result);

        }
    }
}
