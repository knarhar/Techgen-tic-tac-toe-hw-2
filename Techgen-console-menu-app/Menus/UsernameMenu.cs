using MenuLib;
using Techgen_console_menu_app.Core;

namespace Techgen_console_menu_app.Menus
{
    public class UsernameMenu : Menu
    {
        public bool _isPlayer2 { get; set; }
        public UsernameMenu(bool isPlayer2 = false) : base("Welcome") 
        {
            _isPlayer2 = isPlayer2;
        }

        protected override void InternalDisplay()
        {
            if (_isPlayer2)
            {
                Console.WriteLine("Enter second player's username: ");
                return;
            }

            Console.WriteLine("Enter your username and press Enter:");
        }

        public override NavigationResult Display()
        {
            Console.Clear();
            Console.WriteLine($"========== Welcome ============");
            Console.WriteLine();
            InternalDisplay();

            string input = Console.ReadLine()?.Trim() ?? "Player";
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (_isPlayer2)
                {
                    Session.Username2 = input;
                    return NavigationResult.GoTo(new SignSelectionMenu());
                }
                else
                {
                    Session.Username1 = input;
                    return NavigationResult.GoTo(new MainMenu());
                }
            }
            return NavigationResult.None();
        }

        protected override NavigationResult HandleOption(string option)
        {
            return NavigationResult.None();
        }
    }
}