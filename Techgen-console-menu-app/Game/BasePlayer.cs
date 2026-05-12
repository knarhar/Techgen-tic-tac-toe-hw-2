using Techgen_console_menu_app.Contracts;
using Techgen_console_menu_app.Structs;

namespace Techgen_console_menu_app.Game
{
    public abstract class BasePlayer : IGamePlayer
    {
        public string Name { get; }
        public char Sign { get; }

        protected BasePlayer(string name, char sign)
        {
            Name = name;
            Sign = sign;
        }

        public abstract int GetMove(char[] board, Cell cursor);
    }

}