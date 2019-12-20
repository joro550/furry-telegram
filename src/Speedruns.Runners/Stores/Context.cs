using Microsoft.EntityFrameworkCore;
using Speedruns.Runners.Entities;

namespace Speedruns.Runners.Stores
{
    public class Context : DbContext
    {
        public DbSet<RunnerEntity> Runners { get; set; }


        public Context(DbContextOptions options)
            :base(options)
        {
            
        }
    }
}