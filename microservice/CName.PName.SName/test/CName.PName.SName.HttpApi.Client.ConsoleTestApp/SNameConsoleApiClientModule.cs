using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace CName.PName.SName
{
    [DependsOn(
        typeof(SNameHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule))]
    public class SNameConsoleApiClientModule : AbpModule
    {

    }
}
