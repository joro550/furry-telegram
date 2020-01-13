using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Speedruns.Web.Data
{
    public class StreamService
    {
        private readonly ApplicationDbContext _dbContext;

        public StreamService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Stream>> Get()
        {
            var streams = await _dbContext.Streams.ToListAsync();
            return streams.Select(entity => new Stream
            {
                IsOnline = entity.IsOnline,
                Description = entity.Description,
                Platform = entity.Platform,
                Title = entity.Title,
                Username = entity.Username
            }).ToList();
        }
    }
}