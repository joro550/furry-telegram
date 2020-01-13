using System.Collections.Generic;
using Speedruns.Web.Data.Entities;

namespace Speedruns.Web.Seed
{
    public class Streamers
    {
        public static List<Streamer> StreamerList = new List<Streamer>
        {
            new Streamer { Platform = Platform.Twitch, Username = "joro550"},
            new Streamer { Platform = Platform.Twitch, Username = "GamesDoneQuick"},
        };
    }

    public class Streamer
    {
        public string Username { get; set; }
        public Platform Platform { get; set; }
    }
}