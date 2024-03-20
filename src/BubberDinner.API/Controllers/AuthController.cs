using BubberDinner.Application.Services.Auth;
using BubberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult =
                _authService.Register(request.FirstName, request.LastName, request.Email, request.Password);
            var response = new AuthenticationResponse(authResult.Id, authResult.FirstName, authResult.LastName,authResult.Email, authResult.Token);
            return Ok(response);
        }
        [HttpGet("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authService.Login(request.Email, request.Password);
            var response = new AuthenticationResponse(authResult.Id, authResult.FirstName, authResult.LastName, authResult.Email, authResult.Token);
            return Ok(response);
        }
    }
}
