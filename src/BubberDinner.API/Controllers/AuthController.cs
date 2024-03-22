using BubberDinner.Application.Services.Auth;
using BubberDinner.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.API.Controllers
{
    [Route("api/auth")]
    public class AuthController : APIController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr<AuthenticationResult> authResult =
                _authService.Register(request.FirstName, request.LastName, request.Email, request.Password);
            return authResult.Match(authResult => Ok(AuthReturnMapper(authResult)),
                errors => Problem(errors));
        }

        private static AuthenticationResponse AuthReturnMapper(AuthenticationResult result)
        {
            return new AuthenticationResponse(
                result.User.Id, result.User.FirstName, result.User.LastName, result.User.Email, result.Token);
        }
        [HttpGet("login")]
        public IActionResult Login(LoginRequest request)
        {
            ErrorOr<AuthenticationResult>  authResult = _authService.Login(request.Email, request.Password);
            return authResult.Match(authResult => Ok(AuthReturnMapper(authResult)),
                errors => Problem(errors));
        }
    }
}
