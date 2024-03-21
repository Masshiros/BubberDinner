using BubberDinner.Domain.Entities;

namespace BubberDinner.Application.Common.Persistent
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);


    }
}
