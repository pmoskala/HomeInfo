using HomeInfo.Application.Interfaces;
using HomeInfo.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HomeInfo.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {

        private readonly INotificationService _notificationService;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(INotificationService notificationService, IUserRepository userRepository)
        {
            _notificationService = notificationService;
            _userRepository = userRepository;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User entity = _userRepository.AddUser(request.UserName, request.Name, request.Surname, request.Email);

            await Task.Delay(200, cancellationToken);
            // await _notificationService.SendAsync(request);

            return entity;
        }
    }
}
