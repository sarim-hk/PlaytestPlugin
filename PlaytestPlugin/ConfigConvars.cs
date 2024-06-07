using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using Microsoft.Extensions.Logging;

namespace PlaytestPlugin
{
    public partial class PlaytestPlugin
    {
        public string demoUploadURL = string.Empty;

        [ConsoleCommand("pp_demo_upload_endpoint", "If defined, the endpoint to which demos will be uploaded to.")]
        public void DemoUploadEndpoint(CCSPlayerController? player, CommandInfo command)
        {
            if (player != null) return;
            demoUploadURL = command.ArgByIndex(1); 
        }


    }
}
