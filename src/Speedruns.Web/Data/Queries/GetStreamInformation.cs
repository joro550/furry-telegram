using System.Threading.Tasks;
using Speedruns.Web.Data.Entities;
using Speedruns.Web.Data.Queries.Models;
using Streamers.PlatformIntegration;

namespace Speedruns.Web.Data.Queries
{
    public class GetStreamInformation : BaseQuery<StreamInformation>
    {
        private readonly string _userId;
        private readonly ITwitchClient _twitchClient;

        public GetStreamInformation(string userId)
        {
            _userId = userId;
            _twitchClient = PlatformFactory.TwitchClient;
        }

        public override Task<StreamInformation> ForEntity(StreamEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public override async Task<StreamInformation> ForTwitchStream(TwitchStreamEntity entity)
        {
            var user = await _twitchClient.GetStream(_userId);
            if (user.Stream == null)
            {
                return new OfflineStream();
            }

            return new StreamInformation
            {
                Game = user.Stream.Channel.Game,
                Description = user.Stream.Channel.Status,
                Logo = user.Stream.Channel.Logo,
                ViewerCount = user.Stream.Viewers
            };
        }

        public override Task<StreamInformation> ForMixerStream(MixerStreamEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}