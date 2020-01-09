using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Speedruns.Web.Data;

namespace Speedruns.Web.Seed
{
    public static class HostDatabaseExtensions
    {
        public static IHost SeedDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            scope.ServiceProvider.GetService<DataSeeder>()
                .Plant();

            return host;
        }
    }
}