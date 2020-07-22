using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace CName.PName.SName.MongoDB
{
    public class SNameMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public SNameMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}