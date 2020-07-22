using CName.PName.SName.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace CName.PName.SName
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(SNameEntityFrameworkCoreTestModule))]
    public class SNameDomainTestModule : AbpModule
    {

    }
}
