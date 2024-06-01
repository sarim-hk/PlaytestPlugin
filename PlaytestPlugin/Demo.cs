using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Cvars;
using CounterStrikeSharp.API.Modules.Utils;

namespace PlaytestPlugin
{
    public partial class PlaytestPlugin
    {
        public void StartDemo()
        {
            string demoDirectoryPath = Path.GetDirectoryName(Path.Join(Server.GameDirectory + "/csgo/", "PlaytestPlugin"));
            if (demoDirectoryPath != null)
            {
                if (!Directory.Exists(demoDirectoryPath))
                {
                    Directory.CreateDirectory(demoDirectoryPath);
                }
            }

            string demoPath = demoDirectoryPath + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + "_" + Server.MapName + ".dem";
            
            Server.ExecuteCommand($"tv_record {demoPath}");
            isDemoRecording = true;

            Console.WriteLine("[PlaytestPlugin] Demo recording started!");
        }

        public void EndDemo()
        {
            Server.ExecuteCommand("tv_stoprecord");
            isDemoRecording = false;

            Console.WriteLine("[PlaytestPlugin] Demo recording ended!");
        }
    }

}