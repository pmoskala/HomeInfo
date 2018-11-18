using System;

namespace HomeInfo.Domain.Entities
{
    public class User
    {
        public User(string userName, string name, string surname, string email)
        {
            Id = Guid.NewGuid();
            UserName = userName;
            Name = name;
            Surname = surname;
            Email = email;
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
