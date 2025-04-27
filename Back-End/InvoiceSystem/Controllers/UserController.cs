using ApiContract.Dtos;
using ApiContracts;
using BussinessLayer.InterFaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("Get-All-Users")]
        public async Task<ActionResult<GResponse<IEnumerable<UserDto>>>> GetAllUsers()
        {
            var response = await _service.GetAllUsersAsync();
            return Ok(response);
        }

        [HttpGet("Get-User-ById/{id}")]
        public async Task<ActionResult<GResponse<UserDto>>> GetUserById(int id)
        {
            var response = await _service.GetUserByIdAsync(id);
            if (!response.IsSucceeded)
                return NotFound(response);
            return Ok(response);
        }
        [HttpDelete("Delete-User")]
        public async Task<ActionResult<SellerDto>> DeleteUser(int userid)
        {
            var result = await _service.DeleteUserAsync(userid);
            if (!result.IsSucceeded)
                return BadRequest($"failed to delete");

            return Ok(result);
        }
    }

}
