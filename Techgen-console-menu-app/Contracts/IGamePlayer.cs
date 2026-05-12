using Techgen_console_menu_app.Structs;

namespace Techgen_console_menu_app.Contracts
{
    public interface IGamePlayer
    {
        string Name { get; }
        char Sign { get; }
        int GetMove(char[] board, Cell cursor);
    }
}
