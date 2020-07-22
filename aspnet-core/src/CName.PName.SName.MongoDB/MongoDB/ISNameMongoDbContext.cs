using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace CName.PName.SName.MongoDB
{
    [ConnectionStringName(SNameDbProperties.ConnectionStringName)]
    public interface ISNameMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
