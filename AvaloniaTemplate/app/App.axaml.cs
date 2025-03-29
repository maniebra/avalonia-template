using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
#if (CommunityToolkitChosen)
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
#endif
using Avalonia.Markup.Xaml;
using AvaloniaTemplate.Views;
using AvaloniaTemplate.ViewModels;
using AvaloniaTemplate.Views;

namespace AvaloniaTemplate;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
#if (CommunityToolkitChosen)
            DisableAvaloniaDataAnnotationValidation();
#endif
            desktop.MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

#if (CommunityToolkitChosen)
    private void DisableAvaloniaDataAnnotationValidation()
    {
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
#endif
}