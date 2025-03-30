using Avalonia.Markup.Xaml;
using AvaloniaTemplate.Utils;

namespace AvaloniaTemplate.Source.Extensions.MarkupExtensions.Resources;

public class StringsExtension(string key) : MarkupExtension
{
    private string Key { get; } = key;

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        Console.Out.WriteLine(StringResources.get(Key));
        return StringResources.get(Key);
    }
}