using System.IO;
using System.Text.Json.Serialization;

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
}