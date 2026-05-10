using Techgen_console_menu_app.Contracts;

namespace Techgen_console_menu_app.Screens
{
    public enum ScreenActionType
    {
        None,
        Push,
        Back,
        Exit
    }

    public struct ScreenResult
    {
        public ScreenActionType ActionType { get; set; }

        public IScreen? NextScreen { get; set; }
    }
    public abstract class BaseScreen : IScreen
    {
        public abstract void RenderContent();

        public abstract ScreenResult HandleInput(string input);

        public void Render()
        {
            Console.Clear();

            RenderContent();

            RenderFooter();
        }

        protected virtual void RenderFooter()
        {
            Console.WriteLine();
            Console.WriteLine("[back] Return | [exit] Close application");
        }
    }
}
