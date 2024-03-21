using BubberDinner.Domain.Entities;

namespace BubberDinner.Application.Services.Auth
{
    public record AuthenticationResult(User User, string Token);
}
