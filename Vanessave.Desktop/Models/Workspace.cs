using System;
using System.IO;
using System.Text.Json.Serialization;
using Vanessave.Shared.Utils;

namespace Vanessave.Desktop.Models;

public record Workspace
{
    public string Name { get; set; }
    public string Path { get; }

    [JsonIgnore]
    public DirectoryInfo GameSavesDirectory
        => new(System.IO.Path.Combine(Path, "LittleWitchNobeta_Data", "Save"));

    [JsonIgnore]
    public DirectoryInfo SaveStatesDirectory
        => new(System.IO.Path.Combine(Path, "LittleWitchNobeta_Data", "Save", "SaveStates"));

    [JsonIgnore]
    public FileInfo SaveStatesConfigFile
        => new(System.IO.Path.Combine(Path, "BepInEx", "config", "NobetaTrainer", "SaveStates.json"));

    [JsonIgnore]
    public FileInfo SystemSettingsFile
        => new(System.IO.Path.Combine(Path, "LittleWitchNobeta_Data", "Save", "System.dat"));

    public Workspace(string name, string path)
    {
        Name = name;
        Path = path;
    }

    public FileInfo GetGameSaveSlotFile(int slotIndex)
    {
        if (slotIndex is < 1 or > 9)
        {
            throw new ArgumentOutOfRangeException(nameof(slotIndex), "Slot index must be between 1 and 9");
        }

        return new FileInfo(System.IO.Path.Combine(GameSavesDirectory.FullName, $"{NobetaUtils.GameSavePrefix}{slotIndex:D1}.dat"));
    }

    public FileInfo GetSaveStateFile(Guid saveStateId) =>
        new(System.IO.Path.Combine(SaveStatesDirectory.FullName, $"{saveStateId}.dat"));
}