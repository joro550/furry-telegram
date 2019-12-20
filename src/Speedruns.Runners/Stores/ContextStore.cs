using System.Linq;

namespace Speedruns.Runners.Stores
{
    public class ContextStore : IStore
    {
        private readonly Context _context;

        public ContextStore(Context context) 
            => _context = context;

        public IQueryable<T> GetEntities<T>() where T : class 
            => _context.Set<T>();
    }
}