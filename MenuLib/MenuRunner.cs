namespace MenuLib
{
    public static class MenuRunner
    {
        private static readonly MenuStack _navigationStack = new MenuStack();

        public static void Run(Menu root)
        {
            _navigationStack.Push(root);

            while (_navigationStack.Count > 0)
            {
                var currentMenu = _navigationStack.Peek();
                var result = currentMenu.Display();

                switch (result.Type)
                {
                    case NavigationResultType.None:
                        break;
                    case NavigationResultType.GoTo:
                        _navigationStack.Push(result.Menu);
                        break;
                    case NavigationResultType.Wait:
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case NavigationResultType.Back:
                        if (_navigationStack.Count > 1) _navigationStack.Pop();
                        break;
                    case NavigationResultType.Exit:
                        return;
                }
            }
        }
    }
}
