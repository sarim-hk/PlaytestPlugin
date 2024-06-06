using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Cvars;
using CounterStrikeSharp.API.Modules.Utils;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace PlaytestPlugin
{
    public partial class PlaytestPlugin
    {
        public HookResult EventCsWinPanelMatchHandler(EventCsWinPanelMatch @event, GameEventInfo info)
        {
            if (!isMatchStarted)
            {
                return HookResult.Stop;
            }

            EndMatch();
            EndDemo();

            return HookResult.Continue;
        }
    }

}
