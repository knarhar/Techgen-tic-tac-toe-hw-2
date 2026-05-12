namespace Techgen_console_menu_app.Structs
{
    struct MenuOption
    {
        public string Key { get; }
        public string Description { get; }

        public MenuOption(string key, string description)
        {
            Key = key;
            Description = description;
        }
    }
}
