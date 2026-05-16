using Techgen_console_menu_app.Core;
using Techgen_console_menu_app.Enums;
using Techgen_console_menu_app.Structs;

namespace Techgen_console_menu_app.Screens
{
    internal class GameModeScreen : BaseScreen
    {
        public GameModeScreen() : base("Game Mode")
        {
            SetOptions(2);
            AddOption("1", "Player vs Player");
            AddOption("2", "Player vs Computer");
        }

        protected override ScreenResult HandleOption(string input)
        {
            switch (input)
            {
                case "1":
                    Session.GameMode = GameModeTypes.PvP;
                    return ScreenResult.Push(new SetUsernameScreen(true));
                case "2":
                    Session.GameMode = GameModeTypes.PvC;
                    return ScreenResult.Push(new SignSelectionScreen());
                default:
                    return ScreenResult.None();
            }
        }
    }
}
