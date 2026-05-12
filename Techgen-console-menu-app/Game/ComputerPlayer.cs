using Techgen_console_menu_app.Structs;

namespace Techgen_console_menu_app.Game
{
    public class ComputerPlayer : BasePlayer
    {
        public ComputerPlayer(char sign) : base("Computer", sign) { }

        public override int GetMove(char[] board, Cell cursor)
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == '\0')
                    return i;
            }
            return -1;
        }
    }
}
