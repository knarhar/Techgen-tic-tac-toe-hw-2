using Techgen_console_menu_app.Contracts;
using Techgen_console_menu_app.Structs;

public abstract class BaseScreen : IScreen
{
    public string Title { get; }
    private MenuOption[] _options;
    private int _optionCount;

    protected BaseScreen(string title)
    {
        Title = title;
    }

    protected void SetOptions(int count)
    {
        _options = new MenuOption[count];
        _optionCount = 0;
    }

    protected void AddOption(string key, string description)
    {
        _options[_optionCount++] = new MenuOption(key, description);
    }

    public void Render()
    {
        Console.Clear();
        Console.WriteLine($"============ {Title} ============\n");
        RenderContent();
        RenderOptions();
        RenderFooter();
    }

    private void RenderOptions()
    {
        if (_options == null) return;
        foreach (var opt in _options)
            Console.WriteLine($"[{opt.Key}] -- {opt.Description}");
    }

    protected virtual void RenderContent() { }

    private void RenderFooter()
    {
        Console.WriteLine();
        Console.WriteLine("[back] Return | [exit] Exit");
        Console.WriteLine();
    }

    public ScreenResult HandleInput(string input)
    {
        if (input == "back") return ScreenResult.Back();
        if (input == "exit") return ScreenResult.Exit();
        return HandleOption(input);
    }

    protected abstract ScreenResult HandleOption(string input);
}