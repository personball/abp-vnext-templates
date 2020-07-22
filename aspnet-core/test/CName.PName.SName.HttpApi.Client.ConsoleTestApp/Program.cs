using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CName.PName.SName.HttpApi.Client.ConsoleTestApp
{
    class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureServices((hostContext, services) =>
               {
                   services.AddHostedService<ConsoleTestAppHostedService>();
               });

        static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).RunConsoleAsync();
        }
    }
}
