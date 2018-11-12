using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HomeInfo.Application.Interfaces;
using HomeInfo.Application.Notifications;
using HomeInfo.Domain.Entities;
using MediatR;

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
            var entity = new User
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                UserName = request.UserName,
                Name = request.UserName,
                Surname = request.Surname
            };
            await Task.Delay(1000, cancellationToken);
            await _notificationService.SendAsync(new Message {Body = "aa", From = "bb", Subject = "cc", To = "dd"});

            return Unit.Value;
        }
    }
}
