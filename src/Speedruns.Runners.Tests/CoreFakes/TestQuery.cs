using System.Threading.Tasks;
using Speedruns.Runners.Core;
using Speedruns.Runners.Stores;

namespace Speedruns.Runners.Tests.CoreFakes
{
    public class TestQuery : Query<int>
    {
        public override Task<int> Execute(IStore getStore) 
            => Task.FromResult(1);
    }
}