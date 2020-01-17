using System.Threading.Tasks;
using Speedruns.Web.Data.Entities;

namespace Speedruns.Web.Data.Commands
{
    public abstract class BaseCommand
    {
        public abstract Task ForEntity(StreamEntity entity);
        public abstract Task ForTwitchStream(TwitchStreamEntity entity);
        public abstract Task ForMixerStream(MixerStreamEntity entity);
    }
}