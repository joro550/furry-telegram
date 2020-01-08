using System.Linq;
using Speedruns.Runners.Stores;

namespace Speedruns.Runners.Tests.CoreFakes
{
    public class TestStore : IStore
    {
        public bool HasBeenCreated { get; set; }

        public TestStore()
        {
        }

        public IQueryable<T> GetEntities<T>() where T : class
        {
            return null;
        }
    }
}