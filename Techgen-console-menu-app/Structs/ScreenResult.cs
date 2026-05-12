using Techgen_console_menu_app.Enums;
using Techgen_console_menu_app.Contracts;

namespace Techgen_console_menu_app.Structs
{
    public struct ScreenResult
    {
        public MenuActionType ActionType { get; }
        public IScreen? NextScreen { get; }

        private ScreenResult(MenuActionType type, IScreen? next = null)
        {
            ActionType = type;
            NextScreen = next;
        }

        public static ScreenResult None() => new ScreenResult(MenuActionType.None);
        public static ScreenResult Back() => new ScreenResult(MenuActionType.Back);
        public static ScreenResult Exit() => new ScreenResult(MenuActionType.Exit);
        public static ScreenResult Push(IScreen next) => new ScreenResult(MenuActionType.Push, next);
    }
}
