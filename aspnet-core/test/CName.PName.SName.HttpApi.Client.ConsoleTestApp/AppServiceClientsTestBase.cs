using Volo.Abp.MultiTenancy;

namespace CName.PName.SName
{
    public abstract class AppServiceClientsTestBase
    {

        public const string TenantIdentityClientName = "Default";

        public const string InternalIdentityClientName = "Internal";

        public AppServiceClientsTestBase(
            ICurrentTenant currentTenant)
        {
            CurrentTenant = currentTenant;
        }

        public ICurrentTenant CurrentTenant { get; set; }

    }
}
