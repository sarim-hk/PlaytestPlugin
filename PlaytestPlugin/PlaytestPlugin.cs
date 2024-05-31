using CounterStrikeSharp.API.Core;

namespace PlaytestPlugin
{
    public class PlaytestPlugin : BasePlugin
    {
        public override string ModuleName => "PlaytestPlugin";
        public override string ModuleVersion => "0.0.1";

        public override void Load(bool hotReload)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
