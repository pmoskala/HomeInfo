using System.Threading.Tasks;

namespace HomeInfo.Application.Interfaces
{
    public interface IEventStorage
    {
        Task StoreUserEvent(byte[] requestEvent);
    }
}
