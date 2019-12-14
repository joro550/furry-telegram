using System;
using TwitchLib.Api;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Update.Runners
{
    public static class Function1
    {
        [FunctionName("UpdateRunnerStatus")]
        public static async Task Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, IConfiguration config, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var api = new TwitchAPI
            {
                Settings = 
                {
                    ClientId = config["Twitch.ClientId"],
                    AccessToken = config["Twitch.AccessToken"]
                }
            };


            var user = await api.V5.Users.GetUserByNameAsync("joro550");
            var isOnline = await api.V5.Streams.BroadcasterOnlineAsync(user.Matches[0].Id);

        }
    }
}
