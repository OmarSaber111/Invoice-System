using ApiContract.Dtos;
using BussinessLayer.InterFaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signup")]

        public async Task<IActionResult> SignUp([FromBody] SignUpDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            var result = await _authService.SignUpAsync(dto);
            if (!result.IsSucceeded)
                return BadRequest(result.ErrorMessage ?? "Failed signup");

            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            var result = await _authService.LoginAsync(loginDto);

            if (!result.IsSucceeded)
                return Unauthorized(result.ErrorMessage ?? "Invalid username or password");

            return Ok(result);
        }
        [HttpPost("SignOut")]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {

            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            await _authService.SignOutAsync(token);
            return Ok(new { message = "Signed out successfully" });
        }


    }
}