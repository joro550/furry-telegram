using System.Threading.Tasks;
using Speedruns.Runners.Stores;

namespace Speedruns.Runners.Core
{
    public abstract class Query<T>
    {
        public abstract Task<T> Execute(IStore getStore);
    }
}