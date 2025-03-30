using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaTemplate.ViewModels;
using AvaloniaTemplate.Views;
using ResourceLoader = AvaloniaTemplate.Utils.ResourceLoader;

namespace AvaloniaTemplate;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var stringResourcesPath = Path.Combine(AppContext.BaseDirectory, "Resources", "Values");
        ResourceLoader.load(stringResourcesPath);

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            desktop.MainWindow = new MainView
            {
                DataContext = new MainViewModel()
            };

        base.OnFrameworkInitializationCompleted();
    }
}