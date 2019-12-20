using Speedruns.Runners.Stores.Factories;

namespace Speedruns.Runners.Stores.Settings
{
    public abstract class Settings
    {
        public abstract StoreFactory CreateStoreFactory();
    }
}