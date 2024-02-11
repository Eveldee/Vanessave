using System.Text.Json.Serialization;

namespace Vanessave.Nobeta;

// Used for save point map
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GameStage
{
    Title,
    Act01_02,
    Act02_01,
    Act03_01,
    Act04_01,
    Act05_02,
    Act06_03,
    Act07,
    Act08,
    BossRush01,
    BossRushEnd
}

// Used for stage index in basic save
public enum GameStageIndex
{
    Title,
    Act01_02,
    Act02_01,
    Act03_01,
    Act04_01,
    Act05_02,
    Act06_03,
    Act07,
    Act08,
    BossRush01,
    BossRushEnd
}