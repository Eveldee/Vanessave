using System;
using Vanessave.Shared.Models.Nobeta;

namespace Vanessave.Desktop.Models;

public record SaveState(Guid Id, string StageName, GameDifficulty Difficulty, int ClearedCount)
{
    public required string SaveName { get; set; }
    public required string GroupName { get; set; }
    public TeleportationPoint? TeleportationPoint { get; set; } = null;
}