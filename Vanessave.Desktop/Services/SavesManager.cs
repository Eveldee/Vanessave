using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MudBlazor;
using NativeFileDialogs.Net;
using Vanessave.Desktop.Models;
using Vanessave.Desktop.Utils;
using Vanessave.Shared.Models.Nobeta;
using Vanessave.Shared.Services;
using Vanessave.Shared.Utils;
using Vanessave.Shared.Utils.Extensions;

namespace Vanessave.Desktop.Services;

public class SavesManager
{
    private readonly SaveCipherProvider _saveCipherProvider;
    private readonly SettingsProvider _settingsProvider;

    public SavesManager(SaveCipherProvider saveCipherProvider, SettingsProvider settingsProvider)
    {
        _saveCipherProvider = saveCipherProvider;
        _settingsProvider = settingsProvider;
    }

    public void DeleteSave(WorkspaceData workspaceData, SaveInfo saveInfo)
    {
        switch (saveInfo.SaveType)
        {
            case SaveType.GameSave:
                workspaceData.GameSaveInfos.Remove(saveInfo);
                break;
            default:
                throw new ArgumentException("SaveInfo can only be of type GameSave", nameof(saveInfo));
        }

        saveInfo.File.Delete();
    }

    public void DeleteArchive(List<SaveInfo> group, SaveInfo saveInfo)
    {
        group.Remove(saveInfo);

        saveInfo.File.Delete();
    }

    public async Task<GameSave?> PickSaveFile()
    {
        // Run on thread pool to avoid UI lock and crash
        NfdStatus? dialogResult = null;
        string? path = null;

        await Task.Run(() =>
        {
            try
            {
                dialogResult = Nfd.OpenDialog(out path, FileUtils.SaveFilters);
            }
            catch
            {
                dialogResult = null;
            }
        });

        if (dialogResult != NfdStatus.Ok || path is null)
        {
            return null;
        }

        var fileInfo = new FileInfo(path);

        return await ReadGameSave(fileInfo);
    }

    public async Task<FileInfo?> PickSaveAs(string defaultName)
    {
        // Run on thread pool to avoid UI lock and crash
        NfdStatus? dialogResult = null;
        string? path = null;

        await Task.Run(() =>
        {
            try
            {
                dialogResult = Nfd.SaveDialog(out path, FileUtils.SaveFilters, defaultName);
            }
            catch
            {
                dialogResult = null;
            }
        });

        if (dialogResult != NfdStatus.Ok || path is null)
        {
            return null;
        }

        return new FileInfo(path);
    }

    public async Task<bool> LoadGameSave(ISnackbar snackbar, Workspace workspace, GameSave gameSave, int slotIndex)
    {
        var destinationFile = workspace.GetGameSaveSlotFile(slotIndex);

        // Check override if save already exists
        if (destinationFile.Exists && !_settingsProvider.Settings.OverrideSaveOnLoad)
        {
            snackbar.AddError($"A save file already exist in slot {slotIndex}");

            return false;
        }

        // Fix slot index
        gameSave.Basic.DataIndex = slotIndex;

        await WriteGameSave(gameSave, destinationFile);

        return true;
    }
    public async Task<bool> LoadGameSave(ISnackbar snackbar, Workspace workspace, FileInfo gameSaveFile, int slotIndex)
    {
        if (await ReadGameSave(gameSaveFile) is { } gameSave)
        {
            return await LoadGameSave(snackbar, workspace, gameSave, slotIndex);
        }

        return false;
    }

    public async Task<GameSave?> ReadGameSave(FileInfo fileInfo)
    {
        if (!fileInfo.Exists)
        {
            return null;
        }

        try
        {
            await using var decryptStream = _saveCipherProvider.GetDecryptStream(fileInfo.OpenRead());
            var gameSave = await JsonUtils.LoadGameSaveAsync(decryptStream);

            return gameSave;
        }
        catch (Exception)
        {
            return null;
        }
    }
    public Task<GameSave?> ReadGameSave(SaveInfo saveInfo)
    {
        return ReadGameSave(saveInfo.File);
    }

    private async Task WriteGameSave(GameSave gameSave, FileInfo destination)
    {
        await using var destinationStream = _saveCipherProvider.GetEncryptStream(destination.Create());

        await JsonUtils.WriteSaveAsync(gameSave, destinationStream);
    }
    public Task WriteGameSave(SaveInfo saveInfo, GameSave gameSave)
    {
        return WriteGameSave(gameSave, saveInfo.File);
    }
}