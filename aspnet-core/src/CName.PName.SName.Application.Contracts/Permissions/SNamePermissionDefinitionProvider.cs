using CName.PName.SName.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace CName.PName.SName.Permissions
{
    public class SNamePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(SNamePermissions.GroupName, L("Permission:SName"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<SNameResource>(name);
        }
    }
}