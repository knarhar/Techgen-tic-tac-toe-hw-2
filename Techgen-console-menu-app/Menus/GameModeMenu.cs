using MenuLib;
using Techgen_console_menu_app.Core;
using Techgen_console_menu_app.Enums;

namespace Techgen_console_menu_app.Menus
{
    public class GameModeMenu : Menu
    {
        public GameModeMenu() : base("Select Game Mode")
        {
            ConfigureOptionSize(2);
            AddOption("1", "Player vs Player");
            AddOption("2", "Player vs Computer");
        }

        protected override NavigationResult HandleOption(string option)
        {
            switch (option)
            {
                case "1":
                    Session.GameMode = GameModeTypes.PvP;
                    return NavigationResult.GoTo(new UsernameMenu(true));
                case "2":
                    Session.GameMode = GameModeTypes.PvC;
                    return NavigationResult.GoTo(new SignSelectionMenu());
            }
            return NavigationResult.None();
        }
    }
}
