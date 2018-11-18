using HomeInfo.Application.Interfaces;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace HomeInfo.Infrastructure.Storage
{
    public class InMemoryEventStorage : IEventStorage
    {
        private static readonly ConcurrentDictionary<int, byte[]> UserEventStorage = new ConcurrentDictionary<int, byte[]>();
        private static readonly ConcurrentDictionary<int, byte[]> GlobalEventStorage = new ConcurrentDictionary<int, byte[]>();

        public Task StoreUserEvent(byte[] requestEvent)
        {
            int eventsCount = GlobalEventStorage.Count;
            GlobalEventStorage.GetOrAdd(eventsCount, requestEvent);

            return Task.CompletedTask;
        }
    }
}
