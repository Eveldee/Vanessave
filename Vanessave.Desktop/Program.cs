using System;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Photino.Blazor;
using Vanessave.Desktop.Components;
using Vanessave.Shared.Utils.Extensions;

namespace Vanessave.Desktop;

internal static class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        var builder = PhotinoBlazorAppBuilder.CreateDefault(args);

        builder.Services
            .AddLogging();

        builder.Services.AddMudServices(configuration =>
        {
            configuration.SnackbarConfiguration.ClearAfterNavigation = true;
            configuration.SnackbarConfiguration.PreventDuplicates = false;
        });

        builder.Services.AddVanessaveServices();

        // Register root component
        builder.RootComponents.Add<App>("app");

        var app = builder.Build();

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