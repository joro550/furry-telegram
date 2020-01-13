using Speedruns.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Speedruns.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<StreamEntity> Streams { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StreamEntity>()
                .HasDiscriminator(entity => entity.Platform)
                .HasValue<TwitchStreamEntity>("Twitch")
                .HasValue<MixerStreamEntity>("Mixer");

            base.OnModelCreating(modelBuilder);
        }
    }
}
