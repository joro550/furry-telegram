using Speedruns.Web.Data;
using Speedruns.Web.Data.Entities;
using System.Linq;
using Speedruns.Web.Data.Queries;

namespace Speedruns.Web.Seed
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _dbContext;

        public DataSeeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Plant()
        {
            _dbContext.Database.EnsureCreated();

            var streams = _dbContext.Streams;

            foreach (var streamer in Streamers.StreamerList)
            {
                if(streams.Any(entity => entity.Username == streamer.Username))
                    continue;

                var streamEntity = StreamEntity.Create(streamer.Platform);
                var streamInformation = streamEntity.Execute(new GetStreamingInformation());

                streamEntity.Title = streamInformation.Title;
                streamEntity.IsOnline = streamInformation.IsOnline;
                streamEntity.Description = streamInformation.Description;
                streams.Add(streamEntity);
            }

            _dbContext.SaveChanges();
        }
    }
}