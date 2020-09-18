using System;
using System.Threading.Tasks;
using Abpluz.Abp.Http.Client.IdentityModel;
using Volo.Abp.MultiTenancy;

namespace CName.PName.SName.Samples
{
    public class SampleAppService_Tests : AppServiceClientsTestBase
    {
        private readonly ISampleAppService _sampleAppService;

        public SampleAppService_Tests(
            ISampleAppService sampleAppService,
            ICurrentTenant currentTenant)
            : base(currentTenant)
        {
            _sampleAppService = sampleAppService;
        }

        public async Task RunAsync()
        {
            using (CurrentTenant.Change(Guid.NewGuid()))
            {
                using (PluzIdentityClientSwitcher.Use("Internal"))
                {
                    await Assert("Call SampleAppService with no auth.", async () => await _sampleAppService.GetAsync());
                }
            }
        }
    }
}
