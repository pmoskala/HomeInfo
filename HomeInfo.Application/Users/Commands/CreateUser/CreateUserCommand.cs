using HomeInfo.Domain.Entities;
using MediatR;
using ProtoBuf;

namespace HomeInfo.Application.Users.Commands.CreateUser
{
    [ProtoContract]
    public class CreateUserCommand : IRequest<User>
    {
        [ProtoMember(1)]
        public string UserName { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public string Surname { get; set; }
        [ProtoMember(4)]
        public string Email { get; set; }
    }
}
