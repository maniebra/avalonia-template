using Avalonia;
using Avalonia.ReactiveUI;
#if (ReactiveUIToolkitChosen)
using Avalonia.ReactiveUI;
#endif

namespace AvaloniaTemplate;

internal sealed class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }

    private static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace()
            .UseReactiveUI();
    }
}