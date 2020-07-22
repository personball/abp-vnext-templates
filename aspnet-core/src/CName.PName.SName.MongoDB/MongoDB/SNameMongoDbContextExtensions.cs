using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace CName.PName.SName.MongoDB
{
    public static class SNameMongoDbContextExtensions
    {
        public static void ConfigureSName(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new SNameMongoModelBuilderConfigurationOptions(
                SNameDbProperties.DbTablePrefix);

            optionsAction?.Invoke(options);
        }
    }
}