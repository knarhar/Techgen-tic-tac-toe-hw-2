using MenuLib;
using Techgen_console_menu_app.Menus;

namespace Techgen_console_menu_app
{
    internal class Program
    {
        static void Main()
        {
            MenuRunner.Run(new UsernameMenu());
        }
    }
}