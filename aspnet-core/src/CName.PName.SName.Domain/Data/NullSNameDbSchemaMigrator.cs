using System.Threading.Tasks;

namespace CName.PName.SName.Data
{
    public class NullSNameDbSchemaMigrator : ISNameDbSchemaMigrator
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}
