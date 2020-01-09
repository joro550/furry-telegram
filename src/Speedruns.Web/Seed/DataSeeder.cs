using Microsoft.EntityFrameworkCore.Internal;
using Speedruns.Web.Data;
using Speedruns.Web.Data.Entities;

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

            if (!_dbContext.Streams.Any())
            {
                _dbContext.Streams.Add(new TwitchStreamEntity
                {
                    Title = "Hello",
                    IsOnline = true,
                    Platform = "Twitch",
                    Username = "GamesDoneQuick",
                    Description = "Hello from AGDQ"
                });

                _dbContext.Streams.Add(new TwitchStreamEntity
                {
                    Title = "Hello",
                    IsOnline = true,
                    Platform = "Twitch",
                    Username = "GamesDoneQuick",
                    Description = "Hello from AGDQ"
                });

                _dbContext.Streams.Add(new TwitchStreamEntity
                {
                    Title = "Hello",
                    IsOnline = true,
                    Platform = "Twitch",
                    Username = "GamesDoneQuick",
                    Description = "Hello from AGDQ"
                });


                _dbContext.Streams.Add(new TwitchStreamEntity
                {
                    Title = "Hello",
                    IsOnline = true,
                    Platform = "Twitch",
                    Username = "GamesDoneQuick",
                    Description = "Hello from AGDQ"
                });
            }

            _dbContext.SaveChanges();
        }
    }
}