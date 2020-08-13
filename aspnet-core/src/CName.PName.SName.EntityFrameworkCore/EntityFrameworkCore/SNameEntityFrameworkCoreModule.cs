using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace CName.PName.SName.EntityFrameworkCore
{
    [DependsOn(
        typeof(SNameDomainModule),
        typeof(AbpEntityFrameworkCoreModule))]
    public class SNameEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<SNameDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddDefaultRepositories<SNameDbContext>();
            });
        }
    }
}