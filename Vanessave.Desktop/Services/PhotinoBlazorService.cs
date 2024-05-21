using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;
using Photino.Blazor;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using Vanessave.Desktop.Components;
using Vanessave.Shared.Services;
using Vanessave.Shared.Utils.Extensions;

namespace Vanessave.Desktop.Services;

public class PhotinoBlazorService : IHostedService
{
    public IServiceProvider ServiceProvider { get; private set; } = null!;

    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly ServiceCollectionInjector _serviceCollectionInjector;

    private readonly ILogger<PhotinoBlazorService> _logger;

    private Thread? _photinoThread;
    private PhotinoBlazorApp? _app;

    public PhotinoBlazorService(IHostApplicationLifetime hostApplicationLifetime, ServiceCollectionInjector serviceCollectionInjector, ILogger<PhotinoBlazorService> logger)
    {
        _hostApplicationLifetime = hostApplicationLifetime;
        _serviceCollectionInjector = serviceCollectionInjector;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting Photino Blazor app...");

        _photinoThread = new Thread(PhotinoUiThread);

        // STAThread is needed on Windows to communicate with Edge WebView2 (COM)
        if (OperatingSystem.IsWindows())
        {
            _photinoThread.SetApartmentState(ApartmentState.STA);
        }

        _photinoThread.Start();

        _logger.LogInformation("Photino blazor app started");

        return Task.CompletedTask;
    }

    private void PhotinoUiThread(object? _)
    {
        var builder = PhotinoBlazorAppBuilder.CreateDefault([]);

        _serviceCollectionInjector.InjectInto(builder.Services);

        builder.Services.AddMudServices(configuration =>
        {
            configuration.SnackbarConfiguration.ClearAfterNavigation = true;
            configuration.SnackbarConfiguration.PreventDuplicates = false;
        });

        builder.Services.AddVanessaveServices();

        builder.Services.AddHotKeys2();

        builder.Services.AddSingleton<TabBarService>();
        builder.Services.AddSingleton<WorkspacesService>();
        builder.Services.AddSingleton<VanessaveSettingsProvider>();
        builder.Services.AddSingleton<IAppPreferencesProvider, AppPreferencesProvider>();
        builder.Services.AddSingleton<SavesManager>();

        // Register root component
        builder.RootComponents.Add<App>("app");

        _app = builder.Build();

        ServiceProvider = _app.Services;

        // Initialize some services
        ServiceProvider.GetRequiredService<VanessaveSettingsProvider>();

        // Customize window
        _app.MainWindow
            .SetMaximized(true)
            .SetIconFile("favicon.ico")
            .SetTitle("Vanessave");

        AppDomain.CurrentDomain.UnhandledException += (_, error) =>
        {
            _app.MainWindow.ShowMessage("Fatal exception", error.ExceptionObject.ToString());
        };

        // Exit when main window is closed
        _app.MainWindow.WindowClosing += (_, _) =>
        {
            // Avoid closing twice the window
            _app = null;

            // Application closed, terminate
            _hostApplicationLifetime.StopApplication();

            return false;
        };

        _app.Run();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Exiting Photino app...");

        _app?.MainWindow.Close();

        _logger.LogInformation("Photino app exited");

        return Task.CompletedTask;
    }
}