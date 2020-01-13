using TwitchLib.Api;
using TwitchLib.Api.Core;

namespace Streamers.PlatformIntegration
{
    public interface ITwitchClient
    {
    }

    public class TwitchClient : ITwitchClient
    {
        private TwitchAPI _apiClient;

        public TwitchClient(string clientId, string accessToken) 
            => _apiClient = new TwitchAPI(settings: new ApiSettings {ClientId = clientId, AccessToken = accessToken});
    }
}
