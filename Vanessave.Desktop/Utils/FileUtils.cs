using System.Collections.Generic;

namespace Vanessave.Desktop.Utils;

public static class FileUtils
{
    public static Dictionary<string, string> ExeFilters { get; } = new()
        {
            { "Game executable", "exe" }
        };
}