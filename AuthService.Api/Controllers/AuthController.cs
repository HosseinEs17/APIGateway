using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Dtos;
using System.Threading.Tasks;

namespace AuthService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var user = await _userService.RegisterAsync(registerDto);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var token = await _userService.LoginAsync(loginDto);
            return Ok(token);
        }
    }
}
