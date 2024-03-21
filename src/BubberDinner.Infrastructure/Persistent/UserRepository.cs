using BubberDinner.Application.Common.Persistent;
using BubberDinner.Domain.Entities;

namespace BubberDinner.Infrastructure.Persistent
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();
        public void Add(User user)
        {
           _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
           return _users.FirstOrDefault(x => x.Email == email);
        }
    }
}
