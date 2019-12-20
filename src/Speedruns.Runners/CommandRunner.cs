using System;
using System.Threading.Tasks;
using Speedruns.Runners.Core;
using Speedruns.Runners.Stores;

namespace Speedruns.Runners
{
    public class CommandRunner
    {
        private readonly StoreFactory _storeFactory;

        public CommandRunner(Func<SettingsBuilder, Settings> buildSettings)
        {
            _storeFactory = buildSettings(new SettingsBuilder())
                .CreateStoreFactory();
        }

        public  async Task<T> Execute<T>(Query<T> testQuery) 
            => await testQuery.Execute(_storeFactory.GetStore());
    }
}