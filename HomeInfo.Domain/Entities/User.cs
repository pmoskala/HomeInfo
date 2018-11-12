﻿using System;

namespace HomeInfo.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
