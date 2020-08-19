using System;
using System.Threading.Tasks;
using CName.PName.SName.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace CName.PName.SName.EntityFrameworkCore
{
    public class EntityFrameworkCoreSNameDbSchemaMigrator : ISNameDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreSNameDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            await _serviceProvider.GetRequiredService<SNameHttpApiHostMigrationsDbContext>().Database.MigrateAsync();
        }
    }
}
