using System.Collections.Generic;

namespace Vanessave.Desktop.Models;

public class WorkspaceData
{
    public string RootPath { get; }

    public List<SaveInfo> GameSaveInfos { get; }

    public SavestatesData? SavestatesData { get; }

    public WorkspaceData(string rootPath, List<SaveInfo> gameSaveInfos, SavestatesData? savestatesData)
    {
        RootPath = rootPath;
        GameSaveInfos = gameSaveInfos;
        SavestatesData = savestatesData;
    }
}