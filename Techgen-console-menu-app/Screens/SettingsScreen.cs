using Techgen_console_menu_app.Core;
using Techgen_console_menu_app.Structs;

namespace Techgen_console_menu_app.Screens
{
    public class SettingsScreen : BaseScreen
    {
        public SettingsScreen() : base("Settings")
        {
            SetOptions(1);
            AddOption("1", "Change username");
        }

        protected override void RenderContent()
        {
            Console.WriteLine($"Current username: {Session.Username1}");
        }

        protected override ScreenResult HandleOption(string input)
        {
            if (input == "1")
            {
                Console.Write("Enter new username: ");
                string name = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(name))
                    Session.Username1 = name;
            }
            return ScreenResult.None();
        }
    }
}
