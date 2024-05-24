using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MudBlazor;
using NativeFileDialogs.Net;
using Vanessave.Desktop.Components.Pages;
using Vanessave.Desktop.Models;
using Vanessave.Desktop.Utils;
using Vanessave.Desktop.Utils.Extensions;
using Vanessave.Shared.Services;
using Vanessave.Shared.Utils;
using Vanessave.Shared.Utils.Extensions;

namespace Vanessave.Desktop.Services;

public class WorkspacesService
{
    public IEnumerable<Workspace> Workspaces => Settings.Workspaces;

    private const string GameExecutableName = "LittleWitchNobeta.exe";

    private readonly ILogger<WorkspacesService> _logger;
    private readonly SettingsProvider _settingsProvider;
    private readonly TabBarService _tabBarService;
    private readonly SaveCipherProvider _saveCipherProvider;

    private VanessaveSettings Settings => _settingsProvider.Settings;

    public WorkspacesService(ILogger<WorkspacesService> logger, SettingsProvider settingsProvider, TabBarService tabBarService, SaveCipherProvider saveCipherProvider)
    {
        _logger = logger;
        _settingsProvider = settingsProvider;
        _tabBarService = tabBarService;
        _saveCipherProvider = saveCipherProvider;
    }

    public Workspace? Add(ISnackbar snackbar)
    {
        NfdStatus dialogResult;
        string? path;

        try
        {
            dialogResult = Nfd.OpenDialog(out path, FileUtils.ExeFilters);
        }
        catch
        {
            return null;
        }

        if (dialogResult != NfdStatus.Ok || path is null)
        {
            return null;
        }

        var fileInfo = new FileInfo(path);

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
        _tabBarService.OpenWorkspace(workspace);
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

    public async Task<WorkspaceData> LoadWorkspaceData(Workspace workspace)
    {
        // Load system settings
        await using var systemSettingsStream = _saveCipherProvider.GetDecryptStream(workspace.SystemSettingsFile.OpenRead());
        var systemSettings = await JsonUtils.LoadSystemSettingsAsync(systemSettingsStream);

        if (systemSettings is null)
        {
            _logger.LogError("Couldn't load system settings for workspace '{Name}'", workspace.Name);
        }

        // Load game saves
        var gameSaveInfos = new List<SaveInfo>();

        if (workspace.GameSavesDirectory.Exists)
        {
            foreach (var gameSaveFile in workspace.GameSavesDirectory.EnumerateFiles("*.dat", SearchOption.TopDirectoryOnly)
                         .Where(saveFile => saveFile.Name.Length == 14 && saveFile.Name.StartsWith(NobetaUtils.GameSavePrefix)))
            {
                try
                {
                    // Load save
                    await using var decryptStream = _saveCipherProvider.GetDecryptStream(gameSaveFile.OpenRead());
                    var gameSave = await JsonUtils.LoadGameSaveAsync(decryptStream);

                    if (gameSave is null)
                    {
                        _logger.LogWarning("Unable to load save at '{Path}', skipping...", gameSaveFile.FullName);

                        continue;
                    }

                    gameSaveInfos.Add(new SaveInfo(
                        SaveType.GameSave,
                        $"Slot {gameSave.Basic.DataIndex}",
                        NobetaUtils.StageToFriendlyName(gameSave),
                        gameSave.Basic.Difficulty,
                        gameSave.Basic.GameCleared,
                        gameSaveFile.FullName
                    ));
                }
                catch (Exception e)
                {
                    _logger.LogWarning("Unable to load save at '{Path}': {Error}, skipping...", gameSaveFile.FullName, e.Message);
                }
            }
        }

        // Load savestates (if present)
        // TODO

        // Return data
        return new WorkspaceData(workspace, systemSettings!, gameSaveInfos, null);
    }
}