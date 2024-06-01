using CounterStrikeSharp.API.Core;

namespace PlaytestPlugin
{
    public partial class PlaytestPlugin : BasePlugin
    {
        public override string ModuleName => "PlaytestPlugin";
        public override string ModuleVersion => "0.0.1";

        public override void Load(bool hotReload)
        {
            RegisterEventHandler<EventCsWinPanelMatch>(EventCsWinPanelMatchHandler);

            Console.WriteLine("[PlaytestPlugin] Hello World!");
        }
    }

}
