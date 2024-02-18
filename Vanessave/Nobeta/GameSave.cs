// ReSharper disable ClassNeverInstantiated.Global

using System.Text.Json.Serialization;

namespace Vanessave.Nobeta;

public class GameSave
{
    public int DataVersion { get; set; }
    public required Basic Basic { get; set; }
    public required Stats Stats { get; set; }
    public required Props Props { get; set; }
    public required Dictionary<string, bool> Flags { get; set; }
    public required Tips Tips { get; set; }
    public required BossRush BossRush { get; set; }
}

public class Basic
{
    public int DataIndex { get; set; }
    public GameDifficulty Difficulty { get; set; }
    public GameStageIndex Stage { get; set; }
    public int SavePoint { get; set; }
    public bool ShowTeleportMenu { get; set; }
    public long TimeStamp { get; set; }
    public int GamingTime { get; set; }
    public int GameCleared { get; set; }
    public required Dictionary<GameStage, List<int>> SavePointMap { get; set; }
}

public class Stats
{
    public double CurrentMoney { get; set; }
    public double CursePercent { get; set; }
    public double CurrentHealthyPoint { get; set; }
    public double CurrentManaPoint { get; set; }
    public MagicType CurrentMagicIndex { get; set; }
    public int HealthyLevel { get; set; }
    public int ManaLevel { get; set; }
    public int StaminaLevel { get; set; }
    public int StrengthLevel { get; set; }
    public int IntelligenceLevel { get; set; }
    public int DexterityLevel { get; set; }
    public int SecretMagicLevel { get; set; }
    public int IceMagicLevel { get; set; }
    public int FireMagicLevel { get; set; }
    public int ThunderMagicLevel { get; set; }
    public int ManaAbsorbLevel { get; set; }
    public int WindMagicLevel { get; set; }
}

public class Props
{
    public int CurrentInventoryIndex { get; set; }
    public int InventorySlots { get; set; }
    public required ItemType[] CurrentItems { get; set; }
    public int TreasureChestCollection { get; set; }
    public required Dictionary<int, bool[]> StageTreasureMap { get; set; }
    public required Dictionary<int, List<SceneItem>> PlayerItemMap { get; set; }
    public required bool[] PropCollection { get; set; }
    public required bool[] NewPropCollection { get; set; }
}

public class SceneItem
{
    // For some reasons those two use Pascal case in the json instead of Camel case
    [JsonPropertyName(nameof(Type))]
    public int Type { get; set; }
    [JsonPropertyName(nameof(Position))]
    public required Position Position { get; set; }
}

public class Position
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public required Normalized Normalized { get; set; }
    public double Magnitude { get; set; }
    public double SqrMagnitude { get; set; }
}

public class Normalized
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public double Magnitude { get; set; }
    public double SqrMagnitude { get; set; }
}

public class Tips
{
    public bool SecretMagicTip { get; set; }
    public bool IceMagicTip { get; set; }
    public bool FireMagicTip { get; set; }
    public bool ThunderMagicTip { get; set; }
    public bool ManaAbsorbTip { get; set; }
    public bool WindMagicTip { get; set; }
}

public class BossRush
{
    public double TotalBattleTime { get; set; }
    public double Boss01Time { get; set; }
    public double Boss01BestTime { get; set; }
    public int Boss01DeadCount { get; set; }
    public double Boss02Time { get; set; }
    public double Boss02BestTime { get; set; }
    public int Boss02DeadCount { get; set; }
    public double Boss03Time { get; set; }
    public double Boss03BestTime { get; set; }
    public int Boss03DeadCount { get; set; }
    public double Boss04Time { get; set; }
    public double Boss04BestTime { get; set; }
    public int Boss04DeadCount { get; set; }
    public double Boss05Time { get; set; }
    public double Boss05BestTime { get; set; }
    public int Boss05DeadCount { get; set; }
    public double Boss06Time { get; set; }
    public double Boss06BestTime { get; set; }
    public int Boss06DeadCount { get; set; }
    public double KnightTime { get; set; }
    public double KnightBestTime { get; set; }
    public int KnightDeadCount { get; set; }
    public double SealGhostTime { get; set; }
    public double SealGhostBestTime { get; set; }
    public int SealGhostDeadCount { get; set; }
    public double GhostGroupTime { get; set; }
    public double GhostGroupBestTime { get; set; }
    public int GhostGroupDeadCount { get; set; }
    public double DollGroupTime { get; set; }
    public double DollGroupBestTime { get; set; }
    public int DollGroupDeadCount { get; set; }
    public double GirlGroupTime { get; set; }
    public double GirlGroupBestTime { get; set; }
    public int GirlGroupDeadCount { get; set; }
    [JsonPropertyName(nameof(TestBattleTime))]
    public double TestBattleTime { get; set; }
}

