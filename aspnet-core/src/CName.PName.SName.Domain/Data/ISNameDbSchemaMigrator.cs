using System.Threading.Tasks;

namespace CName.PName.SName.Data
{
    public interface ISNameDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
