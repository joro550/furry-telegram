using Speedruns.Runners.Stores;

namespace Speedruns.Runners.Tests.CoreFakes
{
    public class TestStore : IStore
    {
        public bool HasBeenCreated { get; set; }

        public TestStore()
        {
        }
    }
}