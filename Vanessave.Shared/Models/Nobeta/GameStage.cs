using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vanessave.Shared.Models.Nobeta;

// Used for save point map
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GameStage
{
    Title,
    [Description("Misty Moon Forest")]
    Act01_02,
    [Description("Okun Shrine")]
    Act02_01,
    [Description("Underground Cave")]
    Act03_01,
    [Description("Lava Ruins")]
    Act04_01,
    [Description("Dark Tunnel")]
    Act05_02,
    [Description("Spirit Realm")]
    Act06_03,
    [Description("Abyss")]
    Act07,
    [Description("Act 08")]
    Act08,
    [Description("Spirit Domain - Trial Tower")]
    BossRush01,
    [Description("Boss Rush End")]
    BossRushEnd
}

// Used for stage index in basic save
public enum GameStageIndex
{
    Title,
    [Description("Misty Moon Forest")]
    Act01_02,
    [Description("Okun Shrine")]
    Act02_01,
    [Description("Underground Cave")]
    Act03_01,
    [Description("Lava Ruins")]
    Act04_01,
    [Description("Dark Tunnel")]
    Act05_02,
    [Description("Spirit Realm")]
    Act06_03,
    [Description("Abyss")]
    Act07,
    [Description("Act 08")]
    Act08,
    [Description("Spirit Domain - Trial Tower")]
    BossRush01,
    [Description("Boss Rush End")]
    BossRushEnd
}