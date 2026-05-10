using Techgen_console_menu_app.Core;

namespace Techgen_console_menu_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Console Navigation App";

            Application app = new Application();

            app.Run();
        }
    }
}