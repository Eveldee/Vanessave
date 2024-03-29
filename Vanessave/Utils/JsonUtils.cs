﻿using System.Text.Json;
using Vanessave.Nobeta;

namespace Vanessave.Utils;

public static class JsonUtils
{
    private static readonly JsonSerializerOptions PrettifyOptions = new()
    {
        WriteIndented = true
    };

    private static readonly JsonSerializerOptions MinifyOptions = new()
    {
        WriteIndented = false
    };

    private static readonly JsonSerializerOptions SaveOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false
    };

    public static string WriteSave(SystemSettings settings)
    {
        return JsonSerializer.Serialize(settings, SaveOptions);
    }
    public static string WriteSave(GameSave gameSave)
    {
        return JsonSerializer.Serialize(gameSave, SaveOptions);
    }

    public static SystemSettings? LoadSystemSettings(string settings)
    {
        return JsonSerializer.Deserialize<SystemSettings>(settings, SaveOptions);
    }

    public static GameSave? LoadGameSave(string settings)
    {
        return JsonSerializer.Deserialize<GameSave>(settings, SaveOptions);
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