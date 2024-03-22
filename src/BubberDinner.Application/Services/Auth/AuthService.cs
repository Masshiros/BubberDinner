using System.ComponentModel;
using BubberDinner.Application.Common.Interfaces.Auth;
using BubberDinner.Application.Common.Persistent;
using BubberDinner.Domain.Common.Errors;
using BubberDinner.Domain.Entities;
using ErrorOr;

namespace BubberDinner.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IUserRepository _userRepository;

        public AuthService(IJwtGenerator jwtGenerator, IUserRepository userRepository)
        {
            _jwtGenerator = jwtGenerator;
            _userRepository = userRepository;
        }
        public AuthenticationResult Login(string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with given email already exists");
            }

            if (user.Password != password)
            {
                throw new Exception("Invalid Password");
            }
            var token = _jwtGenerator.GenerateJwtToken(user);
            return new AuthenticationResult(user,token);
        }

        public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            var user = new User
            {
                FirstName = firstName,
                Email = email,
                LastName = lastName,
                Password = password,
            };
            _userRepository.Add(user);
            Guid userId = Guid.NewGuid();

            var token = _jwtGenerator.GenerateJwtToken(user);
            return new AuthenticationResult(user, token);
        }
    }
}
