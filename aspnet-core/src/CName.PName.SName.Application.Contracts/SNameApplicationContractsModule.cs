using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace CName.PName.SName
{
    [DependsOn(
        typeof(SNameDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule))]
    public class SNameApplicationContractsModule : AbpModule
    {

    }
}
