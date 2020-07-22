using System.Threading.Tasks;
using Xunit;

namespace CName.PName.SName.Samples
{
    public class SampleManager_Tests : SNameDomainTestBase
    {
        // private readonly SampleManager _sampleManager;
        public SampleManager_Tests()
        {
            // _sampleManager = GetRequiredService<SampleManager>();
        }

        [Fact]
#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
        public async Task Method1Async()
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
        {

        }
    }
}
