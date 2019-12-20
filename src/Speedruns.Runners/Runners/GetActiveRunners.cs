using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Speedruns.Runners.Runners.Models;
using Speedruns.Runners.Stores;

namespace Speedruns.Runners.Runners
{
    public class GetActiveRunners
    {
        public async Task<IEnumerable<Runner>> Execute(Context context)
            => await Runner.FromList(context.Runners.Where(entity => entity.IsOnline).ToListAsync());
    }
}