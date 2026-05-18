using MenuLib;
using Techgen_console_menu_app.Core;

namespace Techgen_console_menu_app.Menus
{
    public class MainMenu : Menu
    {
        public MainMenu() : base("Main Menu")
        {
            ConfigureOptionSize(4);
            AddOption("1", "Play");
            AddOption("2", "Settings");
            AddOption("3", "About");
            AddOption("4", "Quit");
        }

        protected override void InternalDisplay()
        {
            Console.WriteLine($"Welcome, {Session.Username1}!");
        }

        protected override NavigationResult HandleOption(string option)
        {
            switch (option)
            {
                case "1": return NavigationResult.GoTo(new GameModeMenu());
                case "2": return NavigationResult.GoTo(new SettingsMenu());
                case "3": return NavigationResult.GoTo(new AboutMenu());
                case "4": return NavigationResult.Exit();
            }
            return NavigationResult.None();
        }
    }
}
