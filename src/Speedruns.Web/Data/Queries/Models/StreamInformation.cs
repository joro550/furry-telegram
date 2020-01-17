namespace Speedruns.Web.Data.Queries.Models
{
    public class StreamInformation
    {
        public virtual bool IsOnline => true;
        public string Game {get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public int ViewerCount { get; set; }
    }

    public class OfflineStream : StreamInformation
    {
        public override bool IsOnline => false;
    }
}