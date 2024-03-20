namespace BubberDinner.Application.Services.Auth
{
    public interface IAuthService
    {
        AuthenticationResult Login( string email, string password);
        AuthenticationResult Register(string firstName, string lastName, string email, string password);

    }
}
