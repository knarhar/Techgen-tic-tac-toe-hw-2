namespace Techgen_console_menu_app.Screens
{
    public class AboutScreen : BaseScreen
    {
        public override void RenderContent()
        {
            Console.WriteLine("This is About.");
        }

        public override ScreenResult HandleInput(string input)
        {
            return input switch
            {
                "back" => new ScreenResult
                {
                    ActionType = ScreenActionType.Back
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
