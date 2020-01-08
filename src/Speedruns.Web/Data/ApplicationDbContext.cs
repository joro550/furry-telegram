using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Speedruns.Web.Data.Entities;

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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StreamEntity>()
                .HasDiscriminator(entity => entity.Platform)
                .HasValue<TwitchStreamEntity>("Twitch")
                .HasValue<MixerStreamEntiy>("Mixer");
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
