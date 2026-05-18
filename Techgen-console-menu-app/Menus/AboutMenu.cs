using MenuLib;
using Techgen_console_menu_app.Core;

namespace Techgen_console_menu_app.Menus
{
    public class AboutMenu : Menu
    {
        public AboutMenu() : base("About me")
        {
            ConfigureOptionSize(0);
        }

        protected override void InternalDisplay()
        {
            Console.WriteLine("Who am I?");
            Console.WriteLine();
            Console.WriteLine("-- Knarik Developer");
            Console.WriteLine("-- from TechGen ACA classes");
            Console.WriteLine("-- 2026");
        }

        protected override NavigationResult HandleOption(string option)
        {
            return NavigationResult.None();
        }
    }
}
