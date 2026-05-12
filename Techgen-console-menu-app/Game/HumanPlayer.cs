using Techgen_console_menu_app.Structs;

namespace Techgen_console_menu_app.Game
{
    public class HumanPlayer : BasePlayer
    {
        public HumanPlayer(string name, char sign) : base(name, sign) { }

        public override int GetMove(char[] board, Cell cursor)
        {
            return cursor.ToIndex();
        }
    }
}
