using Techgen_console_menu_app.Enums;

namespace Techgen_console_menu_app.Core
{
    /// <summary>
    /// Contains player data.
    /// </summary>
    internal class Session
    {
        public static string Username1 { get; set; } = "Player 1";
        public static string Username2 { get; set; } = "Player 2";
        public static GameModeTypes GameMode{ get; set; }
        public static char Player1Sign { get; set; }
        public static char Player2Sign { get; set; }
    }
}
