namespace Vanessave.Shared.Nobeta;

public class SystemSettings
{
    public int DataVersion { get; set; }
    public int CurrentSkin { get; set; }
    public int SpeedSpellcasting { get; set; }
    public int MeleeSpellcasting { get; set; }
    public int ManaAbsorbed { get; set; }
    public int SoulAcquired { get; set; }
    public int EnemiesDefeated { get; set; }
    public int GameCleared { get; set; }
    public required Achievement[] Achievements { get; set; }
    public bool AllTaniaPropsUnlocked { get; set; }
    public bool AllMonicaPropsUnlocked { get; set; }
    public bool AllVanessaPropsUnlock { get; set; }
    public bool AllCatPropsUnlock { get; set; }
    public bool AllNobetaPropsUnlock { get; set; }
    public bool BossRushTitleTips { get; set; }
    public int BossRushCleared { get; set; }
    public int BossRushPerfectCleared { get; set; }
    public bool BossRushMaximumMagic { get; set; }
    public double BossRushBestClearedTime { get; set; }
    public int BossRushBestDeadCount { get; set; }
}

// ReSharper disable once ClassNeverInstantiated.Global
public class Achievement
{
    public int Id { get; set; }
    public bool Unlocked { get; set; }
}
