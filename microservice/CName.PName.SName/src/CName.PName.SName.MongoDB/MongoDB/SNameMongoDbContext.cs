using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace CName.PName.SName.MongoDB
{
    [ConnectionStringName(SNameDbProperties.ConnectionStringName)]
    public class SNameMongoDbContext : AbpMongoDbContext, ISNameMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureSName();
        }
    }
}