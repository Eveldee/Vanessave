using System.Diagnostics;
using System.Runtime.Versioning;

namespace Vanessave.Shared.Utils;

[UnsupportedOSPlatform("browser")]
public static class ProcessUtils
{
    public static void OpenLinkInBrowser(string link)
    {
        Process.Start(new ProcessStartInfo(link)
        {
            UseShellExecute = true
        });
    }
}