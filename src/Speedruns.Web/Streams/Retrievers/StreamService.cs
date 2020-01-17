using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Speedruns.Web.Data;
using Speedruns.Web.Data.Queries;

namespace Speedruns.Web.Streams.Retrievers
{
    public class StreamService
    {
        private readonly ApplicationDbContext _dbContext;

        public StreamService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Stream>> GetAsync()
        {
            var streamers = await _dbContext.Streams.ToListAsync();

            var returnModel = new List<Stream>();

            foreach (var streamer in streamers)
            {
                var externalId = await streamer.Execute(new GetExternalIdentifier());
                var streamerInfo = await streamer.Execute(new GetStreamInformation(externalId));

                if(!streamerInfo.IsOnline)
                    continue;

                returnModel.Add(new Stream
                {
                    Username = streamer.Username,
                    Game = streamerInfo.Game,
                    Description = streamerInfo.Description,
                    Logo = streamerInfo.Logo,
                    ViewerCount = streamerInfo.ViewerCount
                });
            }

            return returnModel;
        }
    }
}