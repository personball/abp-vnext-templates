using System;
using System.Diagnostics;
using System.Threading.Tasks;
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

        protected async Task Assert(string fact, Func<Task> action)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await action.Invoke();
            stopwatch.Stop();
            Console.WriteLine($"{fact} Success...cost:{stopwatch.ElapsedMilliseconds}ms");
        }

        protected async Task<T> Assert<T>(string fact, Func<Task<T>> action, Func<T, bool> predicate)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = await action.Invoke();
            stopwatch.Stop();
            if (predicate.Invoke(result))
            {
                Console.WriteLine($"{fact} Success...cost:{stopwatch.ElapsedMilliseconds}ms");
            }
            else
            {
                throw new Exception($"{fact},Not Expected<--------------ex");
            }

            return result;
        }
    }
}
