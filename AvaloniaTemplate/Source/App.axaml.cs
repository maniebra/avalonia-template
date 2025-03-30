using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaTemplate.Utils;
using AvaloniaTemplate.Views;
using AvaloniaTemplate.ViewModels;

namespace AvaloniaTemplate;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var stringResourcesPath = Path.Combine(AppContext.BaseDirectory, "Resources", "Values", "strings.xml");
        StringResources.load(stringResourcesPath);
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainView
            {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}