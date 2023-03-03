using finalProject.Business.Services.Abstracts.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace finalProject.API.Controllers.Home.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet, Route("current_user")]
        public async Task<IActionResult> CurrentUser()
        {
            string _token = Request.Headers[HeaderNames.Authorization].ToString()?.Replace("Bearer ", "");
            if (_token is not null)
            {
                var response = await _userService.GetCurrentUser(_token);
                return Ok(new {status = 200, message = response.Data});
            }
            return BadRequest();
        }
    }
}
