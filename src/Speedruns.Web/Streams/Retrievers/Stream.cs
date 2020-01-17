using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Speedruns.Web.Streams.Retrievers
{
    public class Stream
    {
        public string Username { get; set; }
        
        public string Game {get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public int ViewerCount { get; set; }

        public async Task PresentStream(IJSRuntime runtime, string elementId) 
            => await runtime.InvokeVoidAsync("embedTwitch", elementId, Username);
    }
}