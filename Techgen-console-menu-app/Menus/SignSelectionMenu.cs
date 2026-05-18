using MenuLib;
using Techgen_console_menu_app.Core;
using Techgen_console_menu_app.Enums;

namespace Techgen_console_menu_app.Menus
{
    public class SignSelectionMenu : Menu
    {
        private readonly bool _isPlayer2;

        public SignSelectionMenu() : base("Select your Sign")
        {
            ConfigureOptionSize(2);
            AddOption("1", "X");
            AddOption("2", "O");
        }

        protected override void InternalDisplay()
        {
            Console.WriteLine($"{Session.Username1} Choose your sign:");
            if (Session.GameMode == GameModeTypes.PvP)
                Console.WriteLine($"The opposite sign will be assigned to {Session.Username2}");
        }

        protected override NavigationResult HandleOption(string input)
        {
            char sign;
            switch (input)
            {
                case "1": sign = 'X'; break;
                case "2": sign = 'O'; break;
                default: return NavigationResult.None();
            }

            Session.Player1Sign = sign;
            Session.Player2Sign = sign == 'X' ? 'O' : 'X';

            return NavigationResult.GoTo(new GameBoardMenu());
        }
    }
}
