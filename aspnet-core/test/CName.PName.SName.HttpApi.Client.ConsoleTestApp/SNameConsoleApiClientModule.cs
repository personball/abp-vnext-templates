using Abpluz.Abp.Http.Client.IdentityModel;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;

namespace CName.PName.SName
{
    [DependsOn(
        typeof(SNameHttpApiClientModule),
        typeof(AbpMultiTenancyModule),
        typeof(PluzAbpHttpClientIdentityModelModule),
        typeof(AbpHttpClientIdentityModelModule))]
    public class SNameConsoleApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpMultiTenancyOptions>(opt => opt.IsEnabled = true);
        }
    }
}
