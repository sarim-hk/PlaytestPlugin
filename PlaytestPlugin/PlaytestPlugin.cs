using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using Microsoft.Extensions.Logging;

namespace PlaytestPlugin
{
    public partial class PlaytestPlugin : BasePlugin
    {
        public override string ModuleName => "PlaytestPlugin";
        public override string ModuleVersion => "0.0.1";

        public override void Load(bool hotReload)
        {
            Server.ExecuteCommand($"exec PlaytestPlugin/config.cfg");
            Server.ExecuteCommand($"exec PlaytestPlugin/config_dev.cfg");

            RegisterEventHandler<EventCsWinPanelMatch>(EventCsWinPanelMatchHandler);

            Logger.LogInformation("[PlaytestPlugin] Plugin loaded!");
        }
    }

}
