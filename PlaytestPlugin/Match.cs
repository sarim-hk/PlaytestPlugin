using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using Microsoft.Extensions.Logging;

namespace PlaytestPlugin
{
    public partial class PlaytestPlugin
    {
        public bool isMatchStarted = false;

        [ConsoleCommand("pp_start_match", "Start a match.")]
        public void StartMatch(CCSPlayerController? player, CommandInfo command)
        {
            if (player != null) return;
            StartDemo();
            isMatchStarted = true;
            Logger.LogInformation("[PlaytestPlugin] Match started!");
        }

        public void EndMatch()
        {
            isMatchStarted = false;
            Logger.LogInformation("[PlaytestPlugin] Match ended!");
        }
    }

}
