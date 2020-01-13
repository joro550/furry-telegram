using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Speedruns.Web.Data.Queries;

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

        public static StreamEntity Create(Platform platform)
        {
            return platform switch
            {
                Entities.Platform.Twitch => (StreamEntity) new TwitchStreamEntity(),
                Entities.Platform.Mixer => new MixerStreamEntity(),
                _ => new UnknownStreamEntity()
            };
        }

        public virtual T Execute<T>(BaseQuery<T> query) 
            => query.ForEntity(this);
    }

    public class UnknownStreamEntity : StreamEntity
    {
    }

    public class TwitchStreamEntity : StreamEntity
    {
        public override T Execute<T>(BaseQuery<T> query)
        {
            return base.Execute(query);
        }
    }

    public class MixerStreamEntity : StreamEntity
    {
        public override T Execute<T>(BaseQuery<T> query)
        {
            return base.Execute(query);
        }
    }
}