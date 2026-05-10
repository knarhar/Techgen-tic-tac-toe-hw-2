using Techgen_console_menu_app.Navigation;
using Techgen_console_menu_app.Screens;
using Techgen_console_menu_app.Contracts;

namespace Techgen_console_menu_app.Core
{
    public class Application
    {
        private readonly NavigationManager _navigation;

        private bool _running = true;

        public Application()
        {
            _navigation = new NavigationManager();

            _navigation.Push(new MainMenuScreen());
        }

        public void Run()
        {
            while (_running)
            {
                IScreen current = _navigation.CurrentScreen;

                current.Render();

                string input = Console.ReadLine() ?? "";

                HandleGlobalCommands(input);

                ScreenResult result = current.HandleInput(input);

                ProcessResult(result);
            }
        }

        private void HandleGlobalCommands(string input)
        {
            if (input == "back")
                _navigation.Back();

            if (input == "exit")
                _running = false;
        }

        private void ProcessResult(ScreenResult result)
        {
            switch (result.ActionType)
            {
                case ScreenActionType.Push:
                    if (result.NextScreen != null)
                        _navigation.Push(result.NextScreen);
                    break;

                case ScreenActionType.Back:
                    _navigation.Back();
                    break;

                case ScreenActionType.Exit:
                    _running = false;
                    break;
            }
        }
    }
}
