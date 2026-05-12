namespace Techgen_console_menu_app.Contracts
{
    public interface IRenderable
    {
        void Render(string player1Name, char player1Sign, string player2Name, char player2Sign, string currentPlayerName, char currentPlayerSign);
    }
}
