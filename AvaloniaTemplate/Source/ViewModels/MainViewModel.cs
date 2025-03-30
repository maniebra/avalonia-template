using AvaloniaTemplate.Generics;

namespace AvaloniaTemplate.ViewModels;

public class MainViewModel : BaseViewModel
{
    public string title { get; } = "Welcome YALL!";
    public object button_text { get; } = "Click me!";
}