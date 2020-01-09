using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Speedruns.Web.Data
{
    public class Stream
    {
        public string Username { get; set; }
        public string Title { get; set; }
        public bool IsOnline { get; set; }
        public string Platform { set; get; }
        public string Description { get; set; }

        public async Task PresentStream(IJSRuntime runtime, string elementId) 
            => await runtime.InvokeVoidAsync("embedTwitch", elementId, Username);
    }
}