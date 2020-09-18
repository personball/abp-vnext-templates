using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;

namespace CName.PName.SName
{
    public static class AbpApplicationExtensions
    {
        public static async Task RunTests<T>(this IAbpApplicationWithInternalServiceProvider application, Func<T, Task> testStart)
        {
            var app = application.ServiceProvider.GetRequiredService<T>();
            System.Console.WriteLine($"{app.GetType().Name} Start...");
            await testStart(app);
            System.Console.WriteLine($"{app.GetType().Name} End");
        }
    }
}
