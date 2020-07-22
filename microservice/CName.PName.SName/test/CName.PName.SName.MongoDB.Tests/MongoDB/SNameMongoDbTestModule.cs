using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace CName.PName.SName.MongoDB
{
    [DependsOn(
        typeof(SNameTestBaseModule),
        typeof(SNameMongoDbModule))]
    public class SNameMongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var connectionString = MongoDbFixture.ConnectionString.EnsureEndsWith('/') +
                                   "Db_" +
                                    Guid.NewGuid().ToString("N");

            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = connectionString;
            });
        }
    }
}