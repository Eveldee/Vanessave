using Vanessave.Shared.Models.Nobeta;

namespace Vanessave.Shared.Utils;

public static class NobetaUtils
{
    public const string GameSavePrefix = "GameSave0";

    public static string StageToFriendlyName(int stage, int savePoint) => (stage, savePoint) switch
    {
        // TODO
        _ => $"Stage{stage} - SavePoint{savePoint}"
    };

    public static string StageToFriendlyName(GameSave gameSave)
    {
        return StageToFriendlyName((int) gameSave.Basic.Stage, gameSave.Basic.SavePoint);
    }
}