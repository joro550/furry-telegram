using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Speedruns.Web.Data.Commands;
using Speedruns.Web.Data.Queries;

namespace Speedruns.Web.Data.Entities
{
    [Table("Stream")]
    public abstract class StreamEntity
    {
        [Key]
        public int Id { get; set; }

        [NotNull]
        public string Username { get; set; }
        
        [NotNull]
        public Platform Platform { get; set; }

        public static StreamEntity Create(Platform platform)
        {
            return platform switch
            {
                Platform.Twitch => (StreamEntity) new TwitchStreamEntity(),
                Platform.Mixer => new MixerStreamEntity(),
                _ => new UnknownStreamEntity()
            };
        }

        public virtual Task<T> Execute<T>(BaseQuery<T> query) 
            => query.ForEntity(this);

        public virtual Task Execute(BaseCommand command) 
            => command.ForEntity(this);
    }

    public class UnknownStreamEntity : StreamEntity
    {
    }

    public class TwitchStreamEntity : StreamEntity
    {
        [NotNull]
        [Column("ExternalId")]
        public string ChannelId { get; set; }

        public override Task<T> Execute<T>(BaseQuery<T> query) 
            => query.ForTwitchStream(this);
        
        public override Task Execute(BaseCommand command) 
            => command.ForTwitchStream(this);

    }

    public class MixerStreamEntity : StreamEntity
    {
        public override Task<T> Execute<T>(BaseQuery<T> query) 
            => query.ForMixerStream(this);
        public override Task Execute(BaseCommand command) 
            => command.ForMixerStream(this);
    }
}