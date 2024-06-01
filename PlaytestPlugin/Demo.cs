using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Cvars;
using CounterStrikeSharp.API.Modules.Utils;
using System.Reflection.Metadata.Ecma335;

namespace PlaytestPlugin
{
    public partial class PlaytestPlugin
    {
        public bool isDemoRecording = false;

        public void StartDemo()
        {
            try
            {
                string demoDirectoryPath = Path.Combine(Server.GameDirectory, "csgo", "PlaytestPlugin");

                if (!Directory.Exists(demoDirectoryPath))
                {
                    Directory.CreateDirectory(demoDirectoryPath);
                }

                string demoFileName = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss").Replace(":", "-") + "_" + Server.MapName + ".dem";
                string demoPath = Path.Combine(demoDirectoryPath, demoFileName);

                Console.WriteLine(demoDirectoryPath);
                Console.WriteLine(demoPath);

                Server.ExecuteCommand($"tv_record {demoPath}");
                isDemoRecording = true;

                Console.WriteLine("[PlaytestPlugin] Demo recording started!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void EndDemo()
        {
            Server.ExecuteCommand("tv_stoprecord");
            isDemoRecording = false;

            Console.WriteLine("[PlaytestPlugin] Demo recording ended!");
        }

        public void WaitForDemoFinalise(string demoPath)
        {
            Console.WriteLine("[PlaytestPlugin] Not yet implemented!");

        }

        public void UploadDemo(string demoPath)
        {
            Console.WriteLine("[PlaytestPlugin] Not yet implemented!");
        }

    }


}