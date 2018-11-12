using System.Threading.Tasks;
using HomeInfo.Application.Interfaces;
using HomeInfo.Application.Notifications;

namespace HomeInfo.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
        {
            return Task.CompletedTask;
        }
    }
}
