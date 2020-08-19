using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace CName.PName.SName.Data
{
    public class SNameDbMigrationService : ITransientDependency
    {
        private readonly IEnumerable<ISNameDbSchemaMigrator> _dbSchemaMigrators;
        private readonly ICurrentTenant _currentTenant;

        public SNameDbMigrationService(
            IDataSeeder dataSeeder,
            IEnumerable<ISNameDbSchemaMigrator> dbSchemaMigrators,
            ICurrentTenant currentTenant)
        {
            _dbSchemaMigrators = dbSchemaMigrators;
            _currentTenant = currentTenant;
        }

        public async Task MigrateAsync()
        {
            await MigrateDatabaseSchemaAsync();
        }

        private async Task MigrateDatabaseSchemaAsync()
        {
            foreach (var migrator in _dbSchemaMigrators)
            {
                await migrator.MigrateAsync();
            }
        }
    }
}
