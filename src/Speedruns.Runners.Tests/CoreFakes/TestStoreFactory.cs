using Xunit;
using Speedruns.Runners.Stores;
using Speedruns.Runners.Stores.Factories;

namespace Speedruns.Runners.Tests.CoreFakes
{
    public class TestStoreFactory : StoreFactory
    {
        private readonly TestStore _testStore;

        public TestStoreFactory(TestStore testStore) 
            => _testStore = testStore;

        public override IStore GetStore()
        {
            _testStore.HasBeenCreated = true;
            return _testStore;
        }

        public class TestStoreFactoryTests
        {
            [Fact]
            public void WhenGettingStore_ThenStoreIsMarkedAsCreated()
            {
                var testStore = new TestStore();
                var factory = new TestStoreFactory(testStore);

                factory.GetStore();
                Assert.True(testStore.HasBeenCreated);
            }

            [Fact]
            public void WhenStoreHasNotBeenRetrieved_ThenItHasNotBeenCreated()
            {
                var testStore = new TestStore();
                var factory = new TestStoreFactory(testStore);
                Assert.False(testStore.HasBeenCreated);
            }
        }
    }
}