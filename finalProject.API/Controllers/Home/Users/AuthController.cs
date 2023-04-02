using finalProject.Business.Services.Abstracts.Users;
using finalProject.Common.Wrappers.Responses.Abstracts;
using finalProject.Entities.DTOs.Users;
using Microsoft.AspNetCore.Mvc;

namespace finalProject.API.Controllers.Home.Users
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost, Route("register")]
        public async Task<IActionResult> Register(RegisterUser_Dto data)
        {
            IResponse response = await _userService.Register(data);
            if (response.Success) return Ok(new { status = 200, message = response.Message });

            return BadRequest(response.Message);
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login(LoginUser_Dto data)
        {
            IResponse response = await _userService.Login(data);
            if (response.Success) return Ok(new { status = 200, message = response.Message });

            return BadRequest(response.Message);
        }
    }
}
