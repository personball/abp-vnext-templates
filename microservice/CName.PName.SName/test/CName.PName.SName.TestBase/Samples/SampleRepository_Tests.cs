using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace CName.PName.SName.Samples
{
    /* Write your custom repository tests like that, in this project, as abstract classes.
     * Then inherit these abstract classes from EF Core & MongoDB test projects.
     * In this way, both database providers are tests with the same set tests.
     */
    public abstract class SampleRepository_Tests<TStartupModule> : SNameTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        // private readonly ISampleRepository _sampleRepository;
        protected SampleRepository_Tests()
        {
            // _sampleRepository = GetRequiredService<ISampleRepository>();
        }

        [Fact]
#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
        public async Task Method1Async()
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
        {

        }
    }
}
