using System.Xml.Linq;

namespace AvaloniaTemplate.Utils;

public static class StringResources
{
    private static readonly Dictionary<string, string> _strings = new();

    public static void load(string path)
    {
        var doc = XDocument.Load(path);
        foreach (var element in doc.Root!.Elements("string"))
        {
            var key = element.Attribute("name")?.Value;
            var value = element.Value;
            if (key != null)
                _strings[key] = value;
        }
    }

    public static string get(string key)
    {
        return _strings.TryGetValue(key, out var value) ? value : $"[missing:{key}]";
    }
}