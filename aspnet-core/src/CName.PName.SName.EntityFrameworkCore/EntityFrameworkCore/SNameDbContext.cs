using System;
using System.Globalization;
using System.Linq.Expressions;
using Abpluz.Abp.LocalizableContents;
using CName.PName.SName.Demos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace CName.PName.SName.EntityFrameworkCore
{
    [ConnectionStringName(SNameDbProperties.ConnectionStringName)]
    public class SNameDbContext : AbpDbContext<SNameDbContext>, ISNameDbContext
    {

        public SNameDbContext(DbContextOptions<SNameDbContext> options)
            : base(options)
        {

        }

        /* Add DbSet for each Aggregate Root here. Example:
        * public DbSet<Question> Questions { get; set; }
        */

        public DbSet<Demo> Demos { get; set; }

        public bool IsCultureEntryFilterEnabled => DataFilter?.IsEnabled<IHasLocalizableContent>() ?? false;

        public string CurrentCultureName => CultureInfo.CurrentCulture.Name;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureSName();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // optionsBuilder.UseSnakeCaseNamingConvention();// didnt solve Property from base type or interface.
        }

        protected override bool ShouldFilterEntity<TEntity>(IMutableEntityType entityType)
        {
            if (typeof(IHasLocalizableContent).IsAssignableFrom(typeof(TEntity)))
            {
                return true;
            }

            return base.ShouldFilterEntity<TEntity>(entityType);
        }

        protected override Expression<Func<TEntity, bool>> CreateFilterExpression<TEntity>()
        {
            var expression = base.CreateFilterExpression<TEntity>();

            if (typeof(IHasLocalizableContent).IsAssignableFrom(typeof(TEntity)))
            {
                // HACK IHasCultureEntry 自动根据当前CultureInfo添加过滤器
                Expression<Func<TEntity, bool>> cultureFilter = e => !IsCultureEntryFilterEnabled || EF.Property<string>(e, nameof(IHasLocalizableContent.CultureName)) == CurrentCultureName;
                expression = expression == null ? cultureFilter : CombineExpressions(expression, cultureFilter);
            }

            return expression;
        }
    }
}