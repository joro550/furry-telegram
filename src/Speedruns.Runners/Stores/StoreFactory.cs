namespace Speedruns.Runners.Stores
{
    public abstract class StoreFactory
    {
        public abstract IStore GetStore();
    }

    public interface IStore
    {

    }
}