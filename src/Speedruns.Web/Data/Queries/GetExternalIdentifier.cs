using System.Threading.Tasks;
using Speedruns.Web.Data.Entities;
using Streamers.PlatformIntegration;

namespace Speedruns.Web.Data.Queries
{
    public class GetExternalIdentifier : BaseQuery<string>
    {
        private readonly string _username;
        private ITwitchClient _twitchClient;

        public GetExternalIdentifier(string username)
        {
            _username = username;
            _twitchClient = PlatformFactory.TwitchClient;
        }

        public GetExternalIdentifier()
        {
            
        }

        public override Task<string> ForEntity(StreamEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public override async Task<string> ForTwitchStream(TwitchStreamEntity entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.ChannelId) && !string.IsNullOrWhiteSpace(entity.Username))
                return entity.ChannelId;

            var userId = await _twitchClient.GetUserIdAsync(_username);
            if (string.IsNullOrWhiteSpace(userId))
            {
                return null;
            }

            return userId;
        }

        public override Task<string> ForMixerStream(MixerStreamEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }

    
}