using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace CName.PName.SName
{
    [DependsOn(
        typeof(SNameApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class SNameHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "SName";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(SNameApplicationContractsModule).Assembly,
                RemoteServiceName);
        }
    }
}
