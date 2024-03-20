namespace BubberDinner.Application.Common.Interfaces.Auth
{
    public interface IJwtGenerator
    {
        string GenerateJwtToken(Guid userid, string firstName, string lastName);

    }
}
