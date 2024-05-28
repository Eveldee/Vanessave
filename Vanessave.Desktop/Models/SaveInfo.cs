using System.IO;
using Vanessave.Shared.Models.Nobeta;

namespace Vanessave.Desktop.Models;

public record SaveInfo
{
    public SaveType SaveType { get; }

    public string SaveName { get; init; }

    public string StageName { get; }

    public GameDifficulty Difficulty { get; }

    public int ClearedCount { get; }

    public FileInfo File { get; init; }

    public SaveInfo(SaveType saveType, string saveName, string stageName, GameDifficulty difficulty, int clearedCount, FileInfo file)
    {
        SaveType = saveType;
        SaveName = saveName;
        StageName = stageName;
        Difficulty = difficulty;
        ClearedCount = clearedCount;
        File = file;
    }
}