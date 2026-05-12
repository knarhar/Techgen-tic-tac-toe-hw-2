
using Techgen_console_menu_app.Enums;

namespace Techgen_console_menu_app.Core
{
    /// <summary>
    /// Contains player data.
    /// </summary>
    internal class Session
    {
        public static string Username { get; set; } = "";
        public static GameModeTypes GameMode{ get; set; }
        public static char Player1Sign { get; set; }
        public static char Player2Sign { get; set; }
    }
}
