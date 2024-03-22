using ErrorOr;

namespace BubberDinner.Application.Services.Auth
{
    public interface IAuthService
    {
        ErrorOr<AuthenticationResult> Login( string email, string password);
        ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);

    }
}
