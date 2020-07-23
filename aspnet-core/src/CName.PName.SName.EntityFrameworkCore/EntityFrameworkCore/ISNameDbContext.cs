using CName.PName.SName.Demos;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace CName.PName.SName.EntityFrameworkCore
{
    [ConnectionStringName(SNameDbProperties.ConnectionStringName)]
    public interface ISNameDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */

        DbSet<Demo> Demos { get; }

    }
}