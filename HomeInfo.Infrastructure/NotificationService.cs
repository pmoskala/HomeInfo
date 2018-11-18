using HomeInfo.Application.Interfaces;
using MediatR;
using System.Threading.Tasks;

namespace HomeInfo.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(IRequest message)
        {
            IRequest a = message;
            return Task.CompletedTask;
        }
    }
}
