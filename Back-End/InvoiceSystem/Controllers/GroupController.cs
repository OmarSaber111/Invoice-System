using ApiContract.Dtos;
using BussinessLayer.InterFaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet("Get-All-Groups")]
        public async Task<IActionResult> GetAllGroups()
        {
            var response = await _groupService.GetAllGroupsAsync();
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok(response);
        }

        [HttpGet("GetGroupById/{id}")]
        public async Task<IActionResult> GetGroupById(int id)
        {
            var response = await _groupService.GetGroupByIdAsync(id);
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok(response);
        }

        [HttpPost("Create-Group")]
        public async Task<IActionResult> CreateGroup([FromBody] CreateGroupDto dto)
        {
            var response = await _groupService.CreateGroupAsync(dto);
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok(response);
        }

        [HttpPut("Update-Group")]
        public async Task<IActionResult> UpdateGroup([FromBody] UpdateGroupDto dto)
        {
            var response = await _groupService.UpdateGroupAsync(dto);
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok(response);
        }

        [HttpDelete("Delete-Group/{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var response = await _groupService.DeleteGroupAsync(id);
            if (!response.IsSucceeded)
                return BadRequest(response.ErrorMessage ?? "failed");
            return Ok("deleted successfully");
        }
    }
}

