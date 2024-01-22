using System.Text.Json;
using Vanessave.Nobeta;

namespace Vanessave.Utils;

public static class JsonUtils
{
    private static readonly JsonSerializerOptions PrettifyOptions = new()
    {
        WriteIndented = true
    };

    private static readonly JsonSerializerOptions SaveOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static string WriteSave(SystemSettings settings)
    {
        return JsonSerializer.Serialize(settings, SaveOptions);
    }

    public static SystemSettings? LoadSystemSettings(string settings)
    {
        return JsonSerializer.Deserialize<SystemSettings>(settings, SaveOptions);
    }

    public static string Prettify(string minimizedJson)
    {
        var element = JsonSerializer.Deserialize<JsonElement>(minimizedJson);

        return JsonSerializer.Serialize(element, PrettifyOptions).Replace("  ", "\t");
    }
}