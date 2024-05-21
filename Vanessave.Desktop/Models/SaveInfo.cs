using Vanessave.Shared.Nobeta;

namespace Vanessave.Desktop.Models;

public record SaveInfo
{
    public SaveType SaveType { get; }

    public string SaveName { get; private set; }

    public string StageName { get; }

    public GameDifficulty Difficulty { get; }

    public int ClearedCount { get; }

    public string FilePath { get; private set; }

    public SaveInfo(SaveType saveType, string saveName, string stageName, GameDifficulty difficulty, int clearedCount, string filePath)
    {
        SaveType = saveType;
        SaveName = saveName;
        StageName = stageName;
        Difficulty = difficulty;
        ClearedCount = clearedCount;
        FilePath = filePath;
    }
}