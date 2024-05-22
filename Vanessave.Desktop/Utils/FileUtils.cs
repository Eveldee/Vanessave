using System.Collections.Generic;

namespace Vanessave.Desktop.Utils;

public static class FileUtils
{
    public static Dictionary<string, string> ExeFilters { get; } = new()
        {
            { "Game executable", "exe" }
        };

    public static Dictionary<string, string> SaveFilters { get; } = new()
    {
        { "Game save", "dat" }
    };

    public static Dictionary<string, string> SettingsFilters { get; } = new()
    {
        { "System settings", "dat" }
    };

    public static Dictionary<string, string> SaveSettingsFilters { get; } = new()
    {
        { "Save or system settings", "dat" }
    };
}