using System.Threading.Tasks;
using Speedruns.Web.Data.Entities;

namespace Speedruns.Web.Data.Commands
{
    public class SetExternalIdentifier : BaseCommand
    {
        private readonly string _externalId;

        public SetExternalIdentifier(string externalId)
        {
            _externalId = externalId;
        }

        public override Task ForEntity(StreamEntity entity)
        {
            return Task.CompletedTask;
        }

        public override Task ForTwitchStream(TwitchStreamEntity entity)
        {
            entity.ChannelId = _externalId;
            return Task.CompletedTask;
        }

        public override Task ForMixerStream(MixerStreamEntity entity)
        {
            return Task.CompletedTask;
        }
    }
}