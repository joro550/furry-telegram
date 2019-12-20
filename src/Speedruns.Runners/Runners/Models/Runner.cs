using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Speedruns.Runners.Entities;

namespace Speedruns.Runners.Runners.Models
{
    public class Runner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOnline { get; set; }
        public string Description { get; set; }
        public string ActiveGameTitle { get; set; }

        private static Runner FromEntity(RunnerEntity entity) =>
            new Runner
            {
                Id = entity.Id,
                Name = entity.Name,
                IsOnline = entity.IsOnline,
                Description = entity.Description,
                ActiveGameTitle = entity.ActiveGameTitle
            };

        public static async Task<IEnumerable<Runner>> FromList(Task<List<RunnerEntity>> entities)
        {
            var runners = await entities;
            return runners.Select(FromEntity);
        }
    }
}
