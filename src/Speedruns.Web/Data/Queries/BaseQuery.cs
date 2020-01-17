using System.Threading.Tasks;
using Speedruns.Web.Data.Entities;

namespace Speedruns.Web.Data.Queries
{
    public abstract class BaseQuery<T>
    {
        public abstract Task<T> ForEntity(StreamEntity entity);
        public abstract Task<T> ForTwitchStream(TwitchStreamEntity entity);
        public abstract Task<T> ForMixerStream(MixerStreamEntity entity);
    }
}