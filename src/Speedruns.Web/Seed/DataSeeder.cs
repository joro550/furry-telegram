using System;
using System.Linq;
using Speedruns.Web.Data;
using System.Threading.Tasks;
using Speedruns.Web.Data.Queries;
using Speedruns.Web.Data.Entities;
using Speedruns.Web.Data.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Speedruns.Web.Seed
{
    public class DataSeeder
    {
        private readonly IServiceProvider _serviceProvider;

        public DataSeeder(IServiceProvider serviceProvider) 
            => _serviceProvider = serviceProvider;

        public void Plant()
            => Task.Run(async () =>
            {
                using var scope = _serviceProvider.CreateScope();
                await PlantAsync(scope.ServiceProvider.GetService<ApplicationDbContext>());
            });

        private static async Task PlantAsync(ApplicationDbContext dbContext)
        {
            try
            {
                await dbContext.Database.EnsureCreatedAsync();
                var streams = dbContext.Streams;

                foreach (var streamer in Streamers.StreamerList)
                {
                    if (streams.Any(entity => entity.Username == streamer.Username))
                        continue;

                    var streamEntity = StreamEntity.Create(streamer.Platform);
                    var externalIdentifier = await streamEntity.Execute(new GetExternalIdentifier(streamer.Username));

                    streamEntity.Username = streamer.Username;
                    await streamEntity.Execute(new SetExternalIdentifier(externalIdentifier));

                    await streams.AddAsync(streamEntity);
                }

                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }
        }
    }
}