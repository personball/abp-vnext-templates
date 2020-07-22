using Volo.Abp.Modularity;

namespace CName.PName.SName
{
    [DependsOn(
        typeof(SNameApplicationModule),
        typeof(SNameDomainTestModule))]
    public class SNameApplicationTestModule : AbpModule
    {

    }
}
