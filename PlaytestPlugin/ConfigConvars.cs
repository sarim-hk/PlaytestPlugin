using CounterStrikeSharp.API.Modules.Cvars;
using Microsoft.Extensions.Logging;

namespace PlaytestPlugin
{
    public partial class PlaytestPlugin
    {
        public FakeConVar<string> demoUploadEndpoint = new("pp_demo_upload_endpoint", "The endpoint to which demos will be uploaded to.", string.Empty);
    }
}
