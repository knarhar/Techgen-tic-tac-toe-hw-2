using Techgen_console_menu_app.Contracts;

namespace Techgen_console_menu_app.Navigation
{
    public class NavigationManager
    {
        private readonly List<IScreen> _screens = new();

        public IScreen CurrentScreen => _screens[^1];

        public void Push(IScreen screen)
        {
            _screens.Add(screen);
        }

        public void Back()
        {
            if (_screens.Count > 1)
                _screens.RemoveAt(_screens.Count - 1);
        }
    }
}
