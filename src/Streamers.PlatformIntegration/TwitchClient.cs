using System.Linq;
using System.Threading.Tasks;
using TwitchLib.Api;
using TwitchLib.Api.Core;
using TwitchLib.Api.V5.Models.Streams;

namespace Streamers.PlatformIntegration
{
    public interface ITwitchClient
    {
        Task<string> GetUserIdAsync(string userName);
        Task<StreamByUser> GetStream(string userId);
    }

    public class TwitchClient : ITwitchClient
    {
        private readonly TwitchAPI _apiClient;

        public TwitchClient(string clientId, string accessToken) 
            => _apiClient = new TwitchAPI(settings: new ApiSettings {ClientId = clientId, AccessToken = accessToken});

        public async Task<string> GetUserIdAsync(string userName)
        {
            var users = await _apiClient.V5.Users.GetUserByNameAsync(userName);
            return users.Total == 0 ? string.Empty : users.Matches.First().Id;
        }

        public Task<StreamByUser> GetStream(string userId)
        {
            return _apiClient.V5.Streams.GetStreamByUserAsync(userId);
        }
    }
}
