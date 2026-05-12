using Techgen_console_menu_app.Structs;

namespace Techgen_console_menu_app.Screens
{
    public class AboutScreen : BaseScreen
    {
        public AboutScreen() : base("About me"){}
        protected override void RenderContent()
        {
            Console.WriteLine("Who am I?");
            Console.WriteLine();
            Console.WriteLine("-- Knarik Developer");
            Console.WriteLine("-- from TechGen ACA classes");
            Console.WriteLine("-- 2026");
        }

        protected override ScreenResult HandleOption(string input)
        {
            return input switch
            {
                _ => ScreenResult.None()
            };
        }
    }
}
