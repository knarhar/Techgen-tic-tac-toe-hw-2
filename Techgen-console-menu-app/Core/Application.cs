using Techgen_console_menu_app.Navigation;
using Techgen_console_menu_app.Screens;
using Techgen_console_menu_app.Contracts;
using Techgen_console_menu_app.Enums;
using Techgen_console_menu_app.Structs;

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

                string input = Console.ReadLine()?.Trim() ?? "";
                if (string.IsNullOrWhiteSpace(input)) continue;

                ScreenResult result = current.HandleInput(input);
                ProcessResult(result);
            }
        }

        private void ProcessResult(ScreenResult result)
        {
            switch (result.ActionType)
            {
                case MenuActionType.Push:
                    if (result.NextScreen != null)
                        _navigation.Push(result.NextScreen);
                    break;
                case MenuActionType.Back:
                    _navigation.Back();
                    break;
                case MenuActionType.Exit:
                    _running = false;
                    break;
            }
        }
    }
}
