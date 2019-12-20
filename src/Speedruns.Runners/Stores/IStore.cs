using System.Linq;

namespace Speedruns.Runners.Stores
{
    public interface IStore
    {
        IQueryable<T> GetEntities<T>() where T : class;
    }
}