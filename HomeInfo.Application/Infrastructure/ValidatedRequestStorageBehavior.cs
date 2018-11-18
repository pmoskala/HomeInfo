using HomeInfo.Application.Extensions;
using HomeInfo.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HomeInfo.Application.Infrastructure
{
    public class ValidatedRequestStorageBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEventStorage _eventStorage;

        public ValidatedRequestStorageBehavior(IEventStorage eventStorage)
        {
            _eventStorage = eventStorage;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TRequest serializableRequest = request;
            await _eventStorage.StoreUserEvent(serializableRequest.Serialize());
            return await next();
        }
    }
}
