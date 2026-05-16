using Techgen_console_menu_app.Core;
using Techgen_console_menu_app.Enums;
using Techgen_console_menu_app.Screens;
using Techgen_console_menu_app.Structs;

internal class SignSelectionScreen : BaseScreen
{
    public SignSelectionScreen() : base("Select your Sign")
    {
        SetOptions(2);
        AddOption("1", "X");
        AddOption("2", "O");
    }

    protected override void RenderContent()
    {
        Console.WriteLine($"{Session.Username1} Choose your sign:");
        if (Session.GameMode == GameModeTypes.PvP) 
            Console.WriteLine($"The opposite sign will be assigned to {Session.Username2}");
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

        Session.Player1Sign = sign;
        Session.Player2Sign = sign == 'X' ? 'O' : 'X';

        return ScreenResult.Push(new GameBoardScreen());
    }
}