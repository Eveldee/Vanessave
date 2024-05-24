using System.Collections.Generic;
using Vanessave.Shared.Models.Nobeta;

namespace Vanessave.Desktop.Models;

public class WorkspaceData
{
    public Workspace Workspace { get; }

    public SystemSettings SystemSettings { get; }

    public List<SaveInfo> GameSaveInfos { get; }

    public SavestatesData? SavestatesData { get; }

    public WorkspaceData(Workspace workspace, SystemSettings systemSettings, List<SaveInfo> gameSaveInfos, SavestatesData? savestatesData)
    {
        Workspace = workspace;
        SystemSettings = systemSettings;
        GameSaveInfos = gameSaveInfos;
        SavestatesData = savestatesData;
    }
}