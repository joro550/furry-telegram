using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Speedruns.Web.Data.Entities
{
    [Table("Stream")]
    public class StreamEntity
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Title { get; set; }
        public bool IsOnline { get; set; }
        public string Platform { set; get; }
        public string Description { get; set; }
    }

    public class TwitchStreamEntity : StreamEntity
    {

    }

    public class MixerStreamEntiy : StreamEntity
    {

    }
}