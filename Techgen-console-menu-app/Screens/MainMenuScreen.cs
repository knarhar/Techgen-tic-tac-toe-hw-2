namespace Techgen_console_menu_app.Screens
{
    public class MainMenuScreen : BaseScreen
    {
        public override void RenderContent()
        {
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("1 - Settings");
            Console.WriteLine("2 - About");
        }

        public override ScreenResult HandleInput(string input)
        {
            return input switch
            {
                "1" => new ScreenResult
                {
                    ActionType = ScreenActionType.Push,
                    NextScreen = new SettingsScreen()
                },

                "2" => new ScreenResult
                {
                    ActionType = ScreenActionType.Push,
                    NextScreen = new AboutScreen()
                },

                "exit" => new ScreenResult
                {
                    ActionType = ScreenActionType.Exit
                },

                _ => new ScreenResult
                {
                    ActionType = ScreenActionType.None
                }
            };
        }
    }
}
