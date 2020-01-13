using Speedruns.Web.Data.Entities;
using Streamers.PlatformIntegration;

namespace Speedruns.Web.Data.Queries
{
    public class GetStreamingInformation : BaseQuery<StreamInformation>
    {
        private ITwitchClient _twitchClient;

        public GetStreamingInformation()
        {
            _twitchClient = PlatformFactory.TwitchClient;
        }

        public override StreamInformation ForEntity(StreamEntity entity)
        {
            return new StreamInformation();
        }

        public override StreamInformation ForTwitchStream(TwitchStreamEntity entity)
        {



            return new StreamInformation();
        }

        public override StreamInformation ForMixerStream(MixerStreamEntity entity)
        {
            return new StreamInformation();
        }
    }

    public class StreamInformation
    {
        public string Title { get; set; }
        public bool IsOnline { get; set; }
        public string Description { get; set; }
    }
}