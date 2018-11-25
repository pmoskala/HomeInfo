using HomeInfo.Domain.Entities;
using System.Collections.Generic;

namespace HomeInfo.Application.Interfaces
{
    public interface IUserRepository
    {
        User AddUser(string userName, string name, string surname, string email);
        IList<User> GetUsers();
        void Clear();
    }
}
