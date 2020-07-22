using CName.PName.SName.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CName.PName.SName
{
    public abstract class SNameController : AbpController
    {
        protected SNameController()
        {
            LocalizationResource = typeof(SNameResource);
        }
    }
}
