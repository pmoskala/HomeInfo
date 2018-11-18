using MediatR;
using System.Threading.Tasks;

namespace HomeInfo.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(IRequest message);
    }
}
