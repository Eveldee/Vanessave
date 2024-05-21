using System;
using System.IO;
using Vanessave.Desktop.Models;

namespace Vanessave.Desktop.Services;

public class SavesManager
{
    public void DeleteSave(WorkspaceData workspaceData, SaveInfo saveInfo)
    {
        switch (saveInfo.SaveType)
        {
            case SaveType.GameSave:
                workspaceData.GameSaveInfos.Remove(saveInfo);
                break;
            case SaveType.SaveState:
                // TODO
                throw new NotImplementedException();
                break;
            default:
                throw new ArgumentException("SaveInfo can only be of type GameSave or SaveState", nameof(saveInfo));
        }

        File.Delete(saveInfo.FilePath);
    }
}