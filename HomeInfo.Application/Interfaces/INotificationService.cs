using System.Threading.Tasks;
using HomeInfo.Application.Notifications;

namespace HomeInfo.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
