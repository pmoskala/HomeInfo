using HomeInfo.Domain.Entities;

namespace HomeInfo.Application.Interfaces
{
    public interface IUserRepository
    {
        User AddUser(string userName, string name, string surname, string email);
    }
}
