using Avalonia;
#if (ReactiveUIToolkitChosen)
using Avalonia.ReactiveUI;
#endif
using System;
using Avalonia.ReactiveUI;

namespace AvaloniaTemplate;

sealed class Program
{
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace()
            .UseReactiveUI();
}