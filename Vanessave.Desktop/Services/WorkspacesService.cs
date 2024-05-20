using System.Collections.Generic;
using System.IO;
using System.Linq;
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

    public Workspace? Add(ISnackbar snackbar)
    {
        var dialogResult = Dialog.FileOpen("exe");

        if (!dialogResult.IsOk)
        {
            return null;
        }

        var fileInfo = new FileInfo(dialogResult.Path);

        if (!fileInfo.Exists || fileInfo.Name is not GameExecutableName || fileInfo.Directory is null)
        {
            snackbar.AddError("Invalid game installation directory");

            return null;
        }

        var workspace = new Workspace(fileInfo.Directory.Name, fileInfo.Directory.FullName);

        // Avoid duplicates
        if (Settings.Workspaces.Any(w => w.Path == workspace.Path))
        {
            return workspace;
        }

        Settings.Workspaces.Add(workspace);
        _settingsProvider.Save(nameof(Settings.Workspaces));

        _logger.LogInformation("Added workspace: {Workspace}", workspace);

        return workspace;
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

    public void UpdateName(Workspace workspace, string newName)
    {
        workspace.Name = newName;
        _settingsProvider.Save(nameof(Settings.Workspaces));
    }

    public bool Remove(Workspace workspace)
    {
        if (Settings.Workspaces.Remove(workspace))
        {
            _settingsProvider.Save(nameof(Settings.Workspaces));

            return true;
        }

        return false;
    }
}