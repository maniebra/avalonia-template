using System.Xml.Linq;

namespace AvaloniaTemplate.Utils;

public static class ResourceLoader
{
    private static readonly Dictionary<string, Dictionary<string, string>> _mapper = new();

    private static Dictionary<string, string> loadEachXMLFile(string path)
    {
        var doc = XDocument.Load(path);
        var dict = new Dictionary<string, string>();
        foreach (var element in doc.Root!.Elements())
        {
            var pair = mapFunction(element);
            dict[pair.Key] = pair.Value;
        }

        return dict;
    }

    public static void load(string path)
    {
        if (!Directory.Exists(path))
            throw new DirectoryNotFoundException($"Directory not found: {path}");

        var xmlFiles = Directory.GetFiles(path, "*.xml");
        foreach (var file in xmlFiles)
        {
            var fileName = Path.GetFileNameWithoutExtension(file);
            _mapper[fileName] = loadEachXMLFile(file);
        }
    }

    public static string get(string key)
    {
        var splittedKey = key.Split("/");
        var dict = splittedKey[0];
        key = splittedKey[1];
        return _mapper[dict].TryGetValue(key, out var value) ? value : $"[missing:{key}]";
    }

    private static KeyValuePair<string, string> mapFunction(XElement element)
    {
        var key = element.Attribute("name")?.Value;
        var value = element.Value;
        if (key == null)
            throw new InvalidDataException("Invalid key; name field cannot be empty!");
        return new KeyValuePair<string, string>(key!, value);
    }
}