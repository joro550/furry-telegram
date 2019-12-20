using Microsoft.EntityFrameworkCore;

namespace Speedruns.Runners.Stores.Factories
{
    public class ContextStoreFactory : StoreFactory
    {
        private readonly DbContextOptions _options;

        public ContextStoreFactory(DbContextOptions options)
        {
            _options = options;
        }

        public override IStore GetStore()
        {
            return new ContextStore(new Context(_options));
        }
    }
}