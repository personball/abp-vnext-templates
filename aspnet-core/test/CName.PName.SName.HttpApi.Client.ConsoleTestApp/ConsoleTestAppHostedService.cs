using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Volo.Abp;

namespace CName.PName.SName.HttpApi.Client.ConsoleTestApp
{
    public class ConsoleTestAppHostedService : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var application = AbpApplicationFactory.Create<SNameConsoleApiClientModule>())
            {
                application.Initialize();

                await application.RunTests<ClientDemoService>(demo => demo.RunAsync());

                application.Shutdown();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
