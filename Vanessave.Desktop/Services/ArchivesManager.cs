using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Vanessave.Desktop.Models;
using Vanessave.Shared.Models.Nobeta;
using Vanessave.Shared.Utils;

namespace Vanessave.Desktop.Services;

public class ArchivesManager
{
    private const string ArchivesDirectoryName = "Archives";
    private static DirectoryInfo ArchivesDirectory { get; } =
        new(Path.Combine(Environment.CurrentDirectory, ArchivesDirectoryName));

    public IEnumerable<KeyValuePair<string, List<SaveInfo>>> Groups => _archives;

    public IEnumerable<string> GroupNames => _archives.Keys;

    public List<SaveInfo>? this[string groupName] => _archives.GetValueOrDefault(groupName);

    private readonly ILogger<ArchivesManager> _logger;
    private readonly SavesManager _savesManager;

    private readonly Dictionary<string, List<SaveInfo>> _archives;

    public ArchivesManager(ILogger<ArchivesManager> logger, SavesManager savesManager)
    {
        _logger = logger;
        _savesManager = savesManager;

        _archives = [];

        LoadArchives().GetAwaiter().GetResult();
    }

    private async Task LoadArchives()
    {
        // Ensure archives directory exists
        if (!ArchivesDirectory.Exists)
        {
            _logger.LogInformation("Creating Archives directory at {Path}", ArchivesDirectory.FullName);

            ArchivesDirectory.Create();
        }

        // Load archives
        foreach (var groupDirectory in ArchivesDirectory.EnumerateDirectories())
        {
            var group = new List<SaveInfo>();
            var groupName = DecodeName(groupDirectory.Name);

            foreach (var archive in groupDirectory.EnumerateFiles("*.dat"))
            {
                // Load save
                var gameSave = await _savesManager.ReadGameSave(archive);

                if (gameSave is null)
                {
                    _logger.LogWarning("Unable to load save at '{Path}', skipping...", archive.FullName);

                    continue;
                }

                // Get name
                var name = DecodeName(Path.GetFileNameWithoutExtension(archive.Name));

                group.Add(new SaveInfo(
                    SaveType.Archive,
                    name,
                    NobetaUtils.StageToFriendlyName(gameSave),
                    gameSave.Basic.Difficulty,
                    gameSave.Basic.GameCleared,
                    archive
                ));
            }

            _archives[groupName] = group;
        }
    }

    public async Task RefreshArchives()
    {
        _archives.Clear();

        await LoadArchives();
    }

    public void Add(string groupName, string saveName, GameSave gameSave)
    {
        // Create SaveInfo from save data
        var saveInfo = new SaveInfo(
            SaveType.Archive,
            saveName,
            NobetaUtils.StageToFriendlyName(gameSave),
            gameSave.Basic.Difficulty,
            gameSave.Basic.GameCleared,
            GetArchiveFile(groupName, saveName)
        );

        AddSaveToGroup(groupName, saveInfo);

        // Write save file on disk
        _savesManager.WriteGameSave(saveInfo, gameSave);
    }
    public void Add(string groupName, string saveName, SaveInfo saveInfo)
    {
        var archiveInfo = saveInfo with
        {
            SaveName = saveName,
            SaveType = SaveType.Archive,
            File = GetArchiveFile(groupName, saveName)
        };


        AddSaveToGroup(groupName, archiveInfo);

        // Write save file on disk
        saveInfo.File.CopyTo(archiveInfo.File.FullName, true);
    }

    private void AddSaveToGroup(string groupName, SaveInfo saveInfo)
    {
        // Check if group needs to be created
        if (_archives.GetValueOrDefault(groupName) is { } group)
        {
            group.Add(saveInfo);
        }
        else
        {
            // Create directory if needed
            var groupDirectory = new DirectoryInfo(Path.Combine(ArchivesDirectory.FullName, EncodeName(groupName)));

            groupDirectory.Create();

            List<SaveInfo> newGroup = [ saveInfo ];

            _archives[groupName] = newGroup;
        }
    }

    public void Rename(string oldGroup, SaveInfo oldSaveInfo, string newGroup, string newSaveName)
    {
        // Move file on disk
        var destinationFile = GetArchiveFile(newGroup, newSaveName);

        oldSaveInfo.File.MoveTo(destinationFile.FullName);

        // Generate new SaveInfo from old one
        var newSaveInfo = oldSaveInfo with
        {
            SaveName = newSaveName,
            File = destinationFile
        };

        // Remove from old group and add to new
        _archives[oldGroup].Remove(oldSaveInfo);
        AddSaveToGroup(newGroup, newSaveInfo);
    }

    private FileInfo GetArchiveFile(string groupName, string archiveName)
        => new(Path.Combine(
            ArchivesDirectory.FullName,
            EncodeName(groupName),
            $"{EncodeName(archiveName)}.dat")
        );

    private static string DecodeName(string base64Name)
        => Encoding.UTF8.GetString(Convert.FromBase64String(base64Name));

    private static string EncodeName(string name)
        => Convert.ToBase64String(Encoding.UTF8.GetBytes(name));
}