using Techgen_console_menu_app.Core;
using Techgen_console_menu_app.Structs;

namespace Techgen_console_menu_app.Screens
{
    public class MainMenuScreen : BaseScreen
    {
        public MainMenuScreen() : base("Main Menu")
        {
            SetOptions(4);
            AddOption("1", "Play");
            AddOption("2", "Settings");
            AddOption("3", "About");
            AddOption("4", "Quit");
        }

        protected override void RenderContent()
        {
            Console.WriteLine($"Welcome, {Session.Username1}!");
        }

        protected override ScreenResult HandleOption(string input)
        {
            return input switch
            {
                "1" => ScreenResult.Push(new GameModeScreen()),
                "2" => ScreenResult.Push(new SettingsScreen()),
                "3" => ScreenResult.Push(new AboutScreen()),
                "4" => ScreenResult.Exit(),
                _ => ScreenResult.None()
            };
        }
    }
}
