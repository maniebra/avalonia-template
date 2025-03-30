using System.Globalization;
using System.Security.Cryptography;
using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using ResourceLoader = AvaloniaTemplate.Utils.ResourceLoader;

namespace AvaloniaTemplate.Source.Extensions.MarkupExtensions.Resources;

public class ResourcesExtension(string key) : MarkupExtension
{
    private string Key { get; } = key;
    
    private Thickness ParseThickness(string value)
    {
        var parts = value.Split(',');
        var doubles = parts.Select(p => double.Parse(p.Trim(), CultureInfo.InvariantCulture)).ToArray();

        return doubles.Length switch
        {
            1 => new Thickness(doubles[0]),
            2 => new Thickness(doubles[0], doubles[1]),
            4 => new Thickness(doubles[0], doubles[1], doubles[2], doubles[3]),
            _ => throw new FormatException("Invalid Thickness format: use 1, 2, or 4 comma-separated numbers.")
        };
    }


    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var value = ResourceLoader.get(Key);

        if (Key.StartsWith("colors/"))
        {
            var color = Color.Parse(value);
            return new SolidColorBrush(color);
        }

        if (Key.StartsWith("dims/"))
        {
            return ParseThickness(value);
        }

        return value;
    }
}