using System.Linq;
using Speedruns.Runners.Core;
using System.Threading.Tasks;
using Speedruns.Runners.Stores;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Speedruns.Runners.Entities;
using Speedruns.Runners.Runners.Models;

namespace Speedruns.Runners.Runners
{
    public class GetActiveRunners : Query<IEnumerable<Runner>>
    {
        public async Task<IEnumerable<Runner>> Execute(Context context)
            => await Runner.FromList(context.Runners.Where(entity => entity.IsOnline).ToListAsync());

        public override async Task<IEnumerable<Runner>> Execute(IStore store) =>
            await Runner.FromList(store.GetEntities<RunnerEntity>().Where(entity => entity.IsOnline)
                .ToListAsync());
    }
}