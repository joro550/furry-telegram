namespace Speedruns.Web.Data
{
    public class Stream
    {
        public string Username { get; set; }
        public string Title { get; set; }
        public bool IsOnline { get; set; }
        public string Platform { set; get; }
        public string Description { get; set; }
    }
}