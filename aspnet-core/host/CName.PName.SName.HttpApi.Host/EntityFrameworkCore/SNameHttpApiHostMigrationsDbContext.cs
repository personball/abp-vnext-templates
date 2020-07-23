using CName.PName.SName.Demos;
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

        public DbSet<Demo> Demos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureSName();
        }
    }
}
