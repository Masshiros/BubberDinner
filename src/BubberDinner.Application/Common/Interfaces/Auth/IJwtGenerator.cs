using BubberDinner.Domain.Entities;

namespace BubberDinner.Application.Common.Interfaces.Auth
{
    public interface IJwtGenerator
    {
        string GenerateJwtToken(User user);

    }
}
