using CName.PName.SName.Localization;
using Volo.Abp.Application.Services;

namespace CName.PName.SName
{
    public abstract class SNameAppService : ApplicationService
    {
        protected SNameAppService()
        {
            LocalizationResource = typeof(SNameResource);
            ObjectMapperContext = typeof(SNameApplicationModule);
        }
    }
}
