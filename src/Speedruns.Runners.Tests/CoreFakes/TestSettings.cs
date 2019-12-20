using Speedruns.Runners.Stores.Settings;
using Speedruns.Runners.Stores.Factories;

namespace Speedruns.Runners.Tests.CoreFakes
{
    public class TestSettings : Settings
    {
        private readonly TestStore _testStore;

        public TestSettings(TestStore testStore) 
            => _testStore = testStore;

        public override StoreFactory CreateStoreFactory() 
            => new TestStoreFactory(_testStore);
    }
}