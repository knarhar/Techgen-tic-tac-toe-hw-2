using Techgen_console_menu_app.Core;
using Techgen_console_menu_app.Enums;
using Techgen_console_menu_app.Screens;
using Techgen_console_menu_app.Structs;

internal class SignSelectionScreen : BaseScreen
{
    private readonly bool _isPlayer2;

    public SignSelectionScreen(bool isPlayer2 = false) : base("Select your Sign")
    {
        _isPlayer2 = isPlayer2;
        SetOptions(2);
        AddOption("1", "X");
        AddOption("2", "O");
    }

    protected override void RenderContent()
    {
        if (Session.GameMode == GameModeTypes.PvP)
            Console.WriteLine(_isPlayer2 ? "Player 2, choose your sign:" : "Player 1, choose your sign:");
        else
            Console.WriteLine("Choose your sign:");
    }

    protected override ScreenResult HandleOption(string input)
    {
        char sign;
        switch (input)
        {
            case "1": sign = 'X'; break;
            case "2": sign = 'O'; break;
            default: return ScreenResult.None();
        }

        if (!_isPlayer2)
        {
            Session.Player1Sign = sign;

            if (Session.GameMode == GameModeTypes.PvP)
                return ScreenResult.Push(new SignSelectionScreen(isPlayer2: true));

            Session.Player2Sign = sign == 'X' ? 'O' : 'X';
        }
        else
        {
            Session.Player2Sign = sign;
        }

        return ScreenResult.Push(new GameBoardScreen());
    }
}