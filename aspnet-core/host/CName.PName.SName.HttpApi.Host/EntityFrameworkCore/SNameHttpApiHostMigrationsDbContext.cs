using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CName.PName.SName.EntityFrameworkCore
{
    public class SNameHttpApiHostMigrationsDbContext : AbpDbContext<SNameHttpApiHostMigrationsDbContext>, ISNameDbContext
    {
        public SNameHttpApiHostMigrationsDbContext(DbContextOptions<SNameHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureSName();
        }
    }
}
