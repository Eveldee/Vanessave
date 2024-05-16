﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using Photino.Blazor;
using Vanessave.Desktop.Components;
using Vanessave.Shared.Utils.Extensions;

namespace Vanessave.Desktop.Services;

public class PhotinoBlazorService : IHostedService
{
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

        // Register root component
        builder.RootComponents.Add<App>("app");

        _app = builder.Build();

        // Customize window
        _app.MainWindow
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