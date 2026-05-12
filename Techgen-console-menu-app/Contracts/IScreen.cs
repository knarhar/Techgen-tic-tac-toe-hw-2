using Techgen_console_menu_app.Structs;

namespace Techgen_console_menu_app.Contracts
{
    public interface IScreen
    {
        void Render();
        ScreenResult HandleInput(string input);
    }
}
