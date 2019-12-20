using Speedruns.Runners.Stores;

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