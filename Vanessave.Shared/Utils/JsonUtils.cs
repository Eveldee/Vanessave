using System.Text.Json;
using Vanessave.Shared.Models.Nobeta;

namespace Vanessave.Shared.Utils;

public static class JsonUtils
{
    public static readonly JsonSerializerOptions PrettifyOptions = new()
    {
        WriteIndented = true
    };

    public static readonly JsonSerializerOptions MinifyOptions = new()
    {
        WriteIndented = false
    };

    public static readonly JsonSerializerOptions SaveOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false
    };

    public static string WriteSystemSettings(SystemSettings settings)
    {
        return JsonSerializer.Serialize(settings, SaveOptions);
    }
    public static async Task WriteSystemSettingsAsync(SystemSettings settings, Stream destination)
    {
        await JsonSerializer.SerializeAsync(destination, settings, SaveOptions);
    }

    public static string WriteSave(GameSave gameSave)
    {
        return JsonSerializer.Serialize(gameSave, SaveOptions);
    }
    public static async Task WriteSaveAsync(GameSave gameSave, Stream destination)
    {
        await JsonSerializer.SerializeAsync(destination, gameSave, SaveOptions);
    }

    public static SystemSettings? LoadSystemSettings(string settings)
    {
        return JsonSerializer.Deserialize<SystemSettings>(settings, SaveOptions);
    }
    public static async Task<SystemSettings?> LoadSystemSettingsAsync(Stream systemSettings)
    {
        return await JsonSerializer.DeserializeAsync<SystemSettings>(systemSettings, SaveOptions);
    }

    public static GameSave? LoadGameSave(string gameSave)
    {
        return JsonSerializer.Deserialize<GameSave>(gameSave, SaveOptions);
    }
    public static GameSave? LoadGameSave(Stream gameSave)
    {
        return JsonSerializer.Deserialize<GameSave>(gameSave, SaveOptions);
    }
    public static async Task<GameSave?> LoadGameSaveAsync(Stream gameSave)
    {
        return await JsonSerializer.DeserializeAsync<GameSave>(gameSave, SaveOptions);
    }

    public static string Prettify(string minimizedJson)
    {
        var element = JsonSerializer.Deserialize<JsonElement>(minimizedJson);

        return JsonSerializer.Serialize(element, PrettifyOptions).Replace("  ", "\t");
    }

    public static string Minify(string prettifiedJson)
    {
        var element = JsonSerializer.Deserialize<JsonElement>(prettifiedJson);

        return JsonSerializer.Serialize(element, MinifyOptions);
    }

    public static bool IsValidSaveJson(string json)
    {
        try
        {
            JsonSerializer.Deserialize<JsonElement>(json, SaveOptions);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}