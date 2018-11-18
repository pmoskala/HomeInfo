using HomeInfo.Application.Interfaces;
using HomeInfo.Domain.Entities;
using System.Collections.Generic;

namespace HomeInfo.Infrastructure.Storage
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static readonly IList<User> Users = new List<User>();
        public User AddUser(string userName, string name, string surname, string email)
        {
            User user = new User(userName, name, surname, email);
            Users.Add(user);
            return user;
        }
    }
}
