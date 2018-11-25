using HomeInfo.Application.Interfaces;
using HomeInfo.Domain.Entities;
using System.Collections.Generic;

namespace HomeInfo.Infrastructure.Storage
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static readonly IList<User> _users = new List<User>();
        public User AddUser(string userName, string name, string surname, string email)
        {
            User user = new User(userName, name, surname, email);
            _users.Add(user);
            return user;
        }

        public IList<User> GetUsers()
        {
            return _users;
        }

        public void Clear()
        {
            _users.Clear();
        }
    }
}
