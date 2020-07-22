using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace CName.PName.SName.EntityFrameworkCore
{
    public class SNameModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public SNameModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}