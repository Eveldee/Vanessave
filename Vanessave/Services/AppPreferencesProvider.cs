using System.Text.Json;
using Microsoft.JSInterop;
using Vanessave.Shared.Services;

namespace Vanessave.Services;

public class AppPreferencesProvider : IAppPreferencesProvider
{
    public event IAppPreferencesProvider.PreferenceChangedHandler? PreferenceChanged;

    private readonly IJSRuntime _jsRuntime;

    public AppPreferencesProvider(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public T GetValue<T>(string key)
    {
        throw new NotImplementedException("Server side only supports async");
    }

    public async Task<T?> GetValueAsync<T>(string key)
    {
        var value = await _jsRuntime.InvokeAsync<string?>("localStorage.getItem", key);

        return value is null ? default : JsonSerializer.Deserialize<T>(value);
    }

    public void SetValue<T>(string key, T value)
    {
        throw new NotImplementedException("Server side only supports async");
    }

    public async Task SetValueAsync<T>(string key, T value)
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, JsonSerializer.Serialize(value));

        if (PreferenceChanged is not null)
        {
            await PreferenceChanged.Invoke(key);
        }
    }
}