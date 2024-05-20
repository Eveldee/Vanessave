using Vanessave.Shared.Utils;

namespace Vanessave.Shared.Services;

public interface IAppPreferencesProvider
{
    public delegate void PreferenceChangedHandler(string preferenceKey);

    public event PreferenceChangedHandler PreferenceChanged;

    public T? GetValue<T>(string key);

    public void SetValue<T>(string key, T value);

    public bool? IsDarkMode
    {
        get => GetValue<bool?>(AppPreferences.IsDarkMode);
        set => SetValue(AppPreferences.IsDarkMode, value);
    }
}