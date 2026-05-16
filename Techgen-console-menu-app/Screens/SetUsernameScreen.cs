using Techgen_console_menu_app.Core;
using Techgen_console_menu_app.Structs;

namespace Techgen_console_menu_app.Screens
{
    public class SetUsernameScreen : BaseScreen
    {
        public bool player2 { get; set; }
        public SetUsernameScreen(bool player2 = false) : base("Welcome:")
        {
            this.player2 = player2;
        }
        protected override void RenderContent()
        {
            if (player2)
            {
                Console.WriteLine("-- Enter the second player's username: ");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Who are you?");
            Console.WriteLine();
            Console.WriteLine("-- Enter your username:");
        }

        protected override ScreenResult HandleOption(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (player2)
                {
                    Session.Username2 = input;
                    return ScreenResult.Push(new SignSelectionScreen());
                }
                else
                {
                    Session.Username1 = input;
                    return ScreenResult.Push(new MainMenuScreen());
                }
            }

            return ScreenResult.None();
        }
    }
}
