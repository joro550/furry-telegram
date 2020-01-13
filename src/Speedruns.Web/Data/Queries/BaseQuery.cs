using Speedruns.Web.Data.Entities;

namespace Speedruns.Web.Data.Queries
{
    public abstract class BaseQuery<T>
    {
        public abstract T ForEntity(StreamEntity entity);
        public abstract T ForTwitchStream(TwitchStreamEntity entity);
        public abstract T ForMixerStream(MixerStreamEntity entity);
    }
}