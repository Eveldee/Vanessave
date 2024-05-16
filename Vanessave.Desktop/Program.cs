using System;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;

namespace Vanessave.Desktop;

internal static class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        var appBuilder = PhotinoBlazorAppBuilder.CreateDefault(args);

        appBuilder.Services
            .AddLogging();

        // Register root component
        appBuilder.RootComponents.Add<App>("app");

        var app = appBuilder.Build();

        // Customize window
        app.MainWindow
            .SetIconFile("favicon.ico")
            .SetTitle("Vanessave");

        AppDomain.CurrentDomain.UnhandledException += (_, error) =>
        {
            app.MainWindow.ShowMessage("Fatal exception", error.ExceptionObject.ToString());
        };

        app.Run();
    }
}