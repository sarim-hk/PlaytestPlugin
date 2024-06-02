using CounterStrikeSharp.API.Modules.Cvars;
using Microsoft.Extensions.Logging;

namespace PlaytestPlugin
{
    public partial class PlaytestPlugin
    {
        public FakeConVar<bool> demoRecordingEnabled = new("pp_record_demos", "Should demos be recorded? Default: true", true);
        public FakeConVar<string> demoUploadEndpoint = new("pp_demo_upload_endpoint", "The endpoint to which demos will be uploaded to.", string.Empty);
    }
}
