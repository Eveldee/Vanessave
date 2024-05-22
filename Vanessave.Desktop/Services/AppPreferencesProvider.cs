using System;
using System.Text.Json;
using Vanessave.Desktop.Models;
using Vanessave.Shared.Services;
using Vanessave.Shared.Utils;

namespace Vanessave.Desktop.Services;

public class AppPreferencesProvider : IAppPreferencesProvider
{
    public event IAppPreferencesProvider.PreferenceChangedHandler? PreferenceChanged;

    private readonly SettingsProvider _settingsProvider;

    private VanessaveSettings Settings => _settingsProvider.Settings;

    public AppPreferencesProvider(SettingsProvider settingsProvider)
    {
        _settingsProvider = settingsProvider;
    }

    public T? GetValue<T>(string key)
    {
        if (Settings.Preferences.TryGetValue(key, out var value))
        {
            return JsonSerializer.Deserialize<T>(value);
        }

        return default;
    }

    public void SetValue<T>(string key, T value)
    {
        Settings.Preferences[key] = JsonSerializer.Serialize(value, JsonUtils.PrettifyOptions);

        _settingsProvider.Save(nameof(Settings.Preferences));

        PreferenceChanged?.Invoke(key);
    }
}