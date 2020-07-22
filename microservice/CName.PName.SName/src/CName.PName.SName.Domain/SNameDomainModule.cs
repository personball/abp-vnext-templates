using Volo.Abp.Modularity;

namespace CName.PName.SName
{
    [DependsOn(
        typeof(SNameDomainSharedModule))]
    public class SNameDomainModule : AbpModule
    {

    }
}
