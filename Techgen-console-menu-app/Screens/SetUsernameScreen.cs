using Techgen_console_menu_app.Core;
using Techgen_console_menu_app.Structs;

namespace Techgen_console_menu_app.Screens
{
    public class SetUsernameScreen : BaseScreen
    {
        public SetUsernameScreen() : base("Welcome:") { }
        protected override void RenderContent()
        {
            Console.WriteLine("Who are you?");
            Console.WriteLine();
            Console.WriteLine("-- Enter your username:");
        }

        protected override ScreenResult HandleOption(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
                Session.Username = input;

            return ScreenResult.Push(new MainMenuScreen());
        }
    }
}
