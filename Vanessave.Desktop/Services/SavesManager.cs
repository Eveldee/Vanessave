using System;
using System.IO;
using System.Threading.Tasks;
using MudBlazor;
using NativeFileDialogs.Net;
using Vanessave.Desktop.Models;
using Vanessave.Desktop.Utils;
using Vanessave.Shared.Nobeta;
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
            case SaveType.SaveState:
                // TODO
                throw new NotImplementedException();
                break;
            default:
                throw new ArgumentException("SaveInfo can only be of type GameSave or SaveState", nameof(saveInfo));
        }

        File.Delete(saveInfo.FilePath);
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

    public async Task<bool> LoadGameSave(ISnackbar snackbar, Workspace workspace, GameSave gameSave, int slotIndex)
    {
        var destinationFile = GetGameSaveSlotFile(workspace, slotIndex);

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

    private async Task<GameSave?> ReadGameSave(FileInfo fileInfo)
    {
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

    private async Task WriteGameSave(GameSave gameSave, FileInfo destination)
    {
        await using var destinationStream = _saveCipherProvider.GetEncryptStream(destination.Create());

        await JsonUtils.WriteSaveAsync(gameSave, destinationStream);
    }

    private async Task<bool> IsValidGameSave(FileInfo fileInfo)
    {
        try
        {
            await using var decryptStream = _saveCipherProvider.GetDecryptStream(fileInfo.OpenRead());
            var gameSave = await JsonUtils.LoadGameSaveAsync(decryptStream);

            return gameSave is not null;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static FileInfo GetGameSaveSlotFile(Workspace workspace, int slotIndex)
    {
        if (slotIndex is < 1 or > 9)
        {
            throw new ArgumentOutOfRangeException(nameof(slotIndex), "Slot index must be between 1 and 9");
        }

        return new FileInfo(Path.Combine(workspace.GameSavesDirectory.FullName, $"{NobetaUtils.GameSavePrefix}{slotIndex:D1}.dat"));
    }
}