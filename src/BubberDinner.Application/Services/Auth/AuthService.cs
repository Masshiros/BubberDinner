using BubberDinner.Application.Common.Interfaces.Auth;

namespace BubberDinner.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IJwtGenerator _jwtGenerator;

        public AuthService(IJwtGenerator jwtGenerator)
        {
            _jwtGenerator = jwtGenerator;
        }
        public AuthenticationResult Login(string email, string password)
        {
          

            return new AuthenticationResult(Guid.NewGuid(), "firstName", "lastName", email, "token");
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            Guid userId = Guid.NewGuid();

            var token = _jwtGenerator.GenerateJwtToken(userId, email, password);
            return new AuthenticationResult(Guid.NewGuid(), firstName, lastName, email, token);
        }
    }
}
