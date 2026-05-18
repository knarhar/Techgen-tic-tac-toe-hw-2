namespace MenuLib
{
    public struct Option
    {
        public string Key { get; }
        public string Value { get; }

        public Option(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }

    public abstract class Menu
    {
        public string Title { get; }

        private Option[] _options;
        private int _optionIndex;
        private int _selectedIndex;

        public Menu(string title)
        {
            Title = title;
            _selectedIndex = 0;
        }

        protected void ConfigureOptionSize(int count)
        {
            _options = new Option[count];
            _optionIndex = 0;
        }

        protected void AddOption(string key, string value)
        {
            _options[_optionIndex] = new Option(key, value);
            _optionIndex++;
        }

        private bool ContainsOption(string key)
        {
            foreach (var option in _options)
                if (option.Key == key) return true;
            return false;
        }

        public virtual NavigationResult Display()
        {
            while (true)
            {
                Render();

                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (_selectedIndex > 0) _selectedIndex--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (_options != null && _selectedIndex < _options.Length - 1) _selectedIndex++;
                        break;

                    case ConsoleKey.Enter:
                        if (_options != null && _options.Length > 0)
                        {
                            string selectedKey = _options[_selectedIndex].Key;
                            return ExecuteOption(selectedKey);
                        }
                        break;

                    case ConsoleKey.Backspace:
                        return NavigationResult.Back();

                    case ConsoleKey.Escape:
                        return NavigationResult.Exit();
                }
            }
        }

        private void Render()
        {
            Console.Clear();
            Console.WriteLine($"=========== {Title} ===========");
            Console.WriteLine();

            InternalDisplay();

            if (_options != null)
            {
                for (int i = 0; i < _options.Length; i++)
                {
                    if (i == _selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine($"  {_options[i].Key} - {_options[i].Value}  ");
                    Console.ResetColor();
                }
            }

            Console.WriteLine();
            Console.WriteLine("--- Navigation ---");
            Console.WriteLine("↑↓ to navigate | Enter to select | Backspace to go back | Esc to exit");
        }

        protected virtual void InternalDisplay() { }

        private NavigationResult ExecuteOption(string option)
        {
            if (ContainsOption(option))
            {
                Console.Clear();
                return HandleOption(option);
            }
            return NavigationResult.None();
        }

        protected abstract NavigationResult HandleOption(string option);
    }
}
