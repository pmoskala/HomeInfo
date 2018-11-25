using HomeInfo.Server;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace HomeInfo.Application.Integration.Tests
{
    public abstract class TestBase
    {
        private readonly IServiceScopeFactory ScopeFactory;
        protected internal ServiceProvider Provider;

        protected TestBase()
        {
            //var host = A.Fake<IHostingEnvironment>();
            //A.CallTo(() => host.ContentRootPath).Returns(Directory.GetCurrentDirectory());

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables().Build();

            Startup startup = new Startup(configuration);
            ServiceCollection services = new ServiceCollection();

            startup.ConfigureServices(services);

            Provider = services.BuildServiceProvider();
            ScopeFactory = Provider.GetService<IServiceScopeFactory>();
        }

        public Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            return ExecuteScopeAsync(sp =>
            {
                IMediator mediator = sp.GetService<IMediator>();
                return mediator.Send(request);
            });
        }

        public Task SendAsync(IRequest request)
        {
            return ExecuteScopeAsync(sp =>
            {
                IMediator mediator = sp.GetService<IMediator>();

                return mediator.Send(request);
            });
        }

        public async Task ExecuteScopeAsync(Func<IServiceProvider, Task> action)
        {
            using (IServiceScope scope = ScopeFactory.CreateScope())
            {
                await action(scope.ServiceProvider);
            }
        }

        public async Task<T> ExecuteScopeAsync<T>(Func<IServiceProvider, Task<T>> action)
        {
            using (IServiceScope scope = ScopeFactory.CreateScope())
            {
                T result = await action(scope.ServiceProvider);
                return result;
            }
        }
    }
}
