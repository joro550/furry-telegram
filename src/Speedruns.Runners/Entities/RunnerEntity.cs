using System.ComponentModel.DataAnnotations;

namespace Speedruns.Runners.Entities
{
    public class RunnerEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOnline { get; set; }
        public string Description { get; set; }
        public string ActiveGameTitle { get; set; }
    }
}