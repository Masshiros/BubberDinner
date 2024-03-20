namespace BubberDinner.Application.Services.Auth
{
    public record AuthenticationResult(Guid Id, string FirstName, string LastName, string Email, string Token);
}
