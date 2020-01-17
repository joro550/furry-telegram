using Microsoft.Extensions.Hosting;

namespace Speedruns.Web.Seed
{
    public static class HostDatabaseExtensions
    {
        public static IHost SeedDatabase(this IHost host)
        {
            new DataSeeder(host.Services)
                .Plant();
            return host;
        }
    }
}