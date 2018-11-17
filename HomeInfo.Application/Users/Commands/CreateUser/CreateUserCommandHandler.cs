using HomeInfo.Application.Interfaces;
using HomeInfo.Application.Notifications;
using HomeInfo.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HomeInfo.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {

        private readonly INotificationService _notificationService;

        public CreateUserCommandHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User entity = new User
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                UserName = request.UserName,
                Name = request.UserName,
                Surname = request.Surname
            };
            await Task.Delay(1000, cancellationToken);
            await _notificationService.SendAsync(new Message { Body = "aa", From = "bb", Subject = "cc", To = "dd" });

            return Unit.Value;
        }
    }
}
