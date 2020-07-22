using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace CName.PName.SName.EntityFrameworkCore
{
    [ConnectionStringName(SNameDbProperties.ConnectionStringName)]
    public class SNameDbContext : AbpDbContext<SNameDbContext>, ISNameDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public SNameDbContext(DbContextOptions<SNameDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureSName();
        }
    }
}