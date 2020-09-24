using System;
using CName.PName.SName.Demos;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore;

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

            builder.Entity<Demo>(opt =>
            {
                opt.Property(s => s.Name).HasMaxLength(32);
                // one to many
                opt.HasMany(s => s.Entries).WithOne().HasForeignKey(nameof(Demo.Id));
            });
            builder.Entity<DemoLocalizableEntry>(opt =>
            {
                // compose primary key
                opt.HasKey(e => new { e.Id, e.CultureName });
            });

            builder.ConfigureLocalizableContentEntities();
        }
    }
}