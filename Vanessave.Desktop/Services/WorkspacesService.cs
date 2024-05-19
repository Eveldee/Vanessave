using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;
using MudBlazor;
using NativeFileDialogSharp;
using Vanessave.Desktop.Components.Pages;
using Vanessave.Desktop.Models;
using Vanessave.Desktop.Utils.Extensions;
using Vanessave.Shared.Utils.Extensions;

namespace Vanessave.Desktop.Services;

public class WorkspacesService
{
    public IEnumerable<Workspace> Workspaces => Settings.Workspaces;

    private const string GameExecutableName = "LittleWitchNobeta.exe";

    private readonly ILogger<WorkspacesService> _logger;
    private readonly VanessaveSettingsProvider _settingsProvider;
    private readonly TabBarService _tabBarService;

    private VanessaveSettings Settings => _settingsProvider.Settings;

    public WorkspacesService(ILogger<WorkspacesService> logger, VanessaveSettingsProvider settingsProvider, TabBarService tabBarService)
    {
        _logger = logger;
        _settingsProvider = settingsProvider;
        _tabBarService = tabBarService;
    }

    public bool Add(ISnackbar snackbar)
    {
        var dialogResult = Dialog.FileOpen("exe");

        if (!dialogResult.IsOk)
        {
            return false;
        }

        var fileInfo = new FileInfo(dialogResult.Path);

        if (!fileInfo.Exists || fileInfo.Name is not GameExecutableName || fileInfo.Directory is null)
        {
            snackbar.AddError("Invalid game installation directory");

            return false;
        }

        var workspace = new Workspace(fileInfo.Directory.Name, fileInfo.Directory.FullName);

        Settings.Workspaces.Add(workspace);
        _settingsProvider.Save(nameof(Settings.Workspaces));

        _logger.LogInformation("Added workspace: {Workspace}", workspace);

        return true;
    }

    public void Open(Workspace workspace)
    {
        _tabBarService.Open(new TabView(
            name: workspace.Name,
            content: builder => builder.AddSimpleComponent<WorkspacePage, Workspace>(workspace),
            closeable: true,
            icon: Icons.Material.Filled.Dashboard,
            caption: "Workspace"
        ));
    }
}