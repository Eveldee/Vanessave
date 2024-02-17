namespace Vanessave.Nobeta;

public static class SaveUtils
{
    public static int MaxHealth(GameSave gameSave) => 84 + gameSave.Stats.HealthyLevel * 6;

    public static int MaxMana(GameSave gameSave) => 114 + gameSave.Stats.ManaLevel * 6;
}