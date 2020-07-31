using CName.PName.SName.Demos;
using Microsoft.EntityFrameworkCore;
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
    }
}