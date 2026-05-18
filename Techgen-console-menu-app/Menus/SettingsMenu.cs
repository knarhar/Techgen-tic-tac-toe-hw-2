using MenuLib;
using Techgen_console_menu_app.Core;

namespace Techgen_console_menu_app.Menus
{
    public class SettingsMenu : Menu
    {
        public SettingsMenu() : base("Settings")
        {
            ConfigureOptionSize(1);
            AddOption("1", "Change username");
        }

        protected override void InternalDisplay()
        {
            Console.WriteLine($"Current username: {Session.Username1}");
            Console.WriteLine();
        }

        protected override NavigationResult HandleOption(string option)
        {
            if (option == "1")
            {
                Console.Clear();
                Console.WriteLine("Enter new username:");
                Console.Write("> ");
                string input = Console.ReadLine()?.Trim() ?? "";
                if (!string.IsNullOrWhiteSpace(input))
                    Session.Username1 = input;
            }
            return NavigationResult.None();
        }
    }
}
