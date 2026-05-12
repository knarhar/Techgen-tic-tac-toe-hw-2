using Techgen_console_menu_app.Contracts;

namespace Techgen_console_menu_app.Navigation
{
    public class NavigationManager
    {
        private readonly NavigationStack _screens = new();

        public IScreen CurrentScreen => _screens.Peek();

        public void Push(IScreen screen)
        {
            _screens.Push(screen);
        }

        public void Back()
        {
            if (_screens.Count > 1)
                _screens.Pop();
        }
    }
}
