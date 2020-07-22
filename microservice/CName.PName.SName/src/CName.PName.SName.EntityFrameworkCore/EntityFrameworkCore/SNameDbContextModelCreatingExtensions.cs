using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace CName.PName.SName.EntityFrameworkCore
{
    public static class SNameDbContextModelCreatingExtensions
    {
        public static void ConfigureSName(
            this ModelBuilder builder,
            Action<SNameModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new SNameModelBuilderConfigurationOptions(
                SNameDbProperties.DbTablePrefix,
                SNameDbProperties.DbSchema);

            optionsAction?.Invoke(options);

            /* Configure all entities here.*/
        }
    }
}