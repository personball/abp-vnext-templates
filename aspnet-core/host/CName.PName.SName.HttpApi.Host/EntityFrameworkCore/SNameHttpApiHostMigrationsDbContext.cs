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

        // https://stackoverflow.com/questions/37493095/entity-framework-core-rc2-table-name-pluralization DbSet PropertyName decide table name as default, without dbset use class name.
        public DbSet<Demo> Demos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureSName();
        }
    }
}
