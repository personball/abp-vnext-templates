using Volo.Abp.Reflection;

namespace CName.PName.SName.Permissions
{
    public class SNamePermissions
    {
        public const string GroupName = "SName";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(SNamePermissions));
        }
    }
}