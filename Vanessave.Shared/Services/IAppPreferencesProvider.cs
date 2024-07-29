using Vanessave.Shared.Utils;

namespace Vanessave.Shared.Services;

public interface IAppPreferencesProvider
{
    public delegate Task PreferenceChangedHandler(string preferenceKey);

    public event PreferenceChangedHandler PreferenceChanged;

    public T? GetValue<T>(string key);
    public Task<T?> GetValueAsync<T>(string key);

    public void SetValue<T>(string key, T value);
    public Task SetValueAsync<T>(string key, T value);

    public Task<bool?> IsDarkModeAsync() => GetValueAsync<bool?>(AppPreferences.IsDarkMode);
    public Task SetDarkModeAsync(bool value) => SetValueAsync(AppPreferences.IsDarkMode, value);

    public bool? IsDarkMode
    {
        get => GetValue<bool?>(AppPreferences.IsDarkMode);
        set => SetValue(AppPreferences.IsDarkMode, value);
    }
}