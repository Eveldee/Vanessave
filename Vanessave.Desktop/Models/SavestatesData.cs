using System.Collections.Generic;
using System.Linq;

namespace Vanessave.Desktop.Models;

public class SavestatesData
{
    public IEnumerable<SaveState> SaveStates { get; }
    public IDictionary<SaveState, SaveInfo> SaveStateInfos { get; }

    public SavestatesData(Workspace workspace, IEnumerable<SaveState> saveStates)
    {
        SaveStates = saveStates;

        SaveStateInfos = saveStates.ToDictionary(
            saveState => saveState,
            saveState => new SaveInfo(
                SaveType.SaveState,
                saveState.SaveName,
                saveState.StageName,
                saveState.Difficulty,
                saveState.ClearedCount,
                workspace.GetSaveStateFile(saveState.Id)
            )
        );
    }
}