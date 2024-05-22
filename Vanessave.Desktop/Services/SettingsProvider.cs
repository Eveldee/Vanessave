using System;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Vanessave.Desktop.Models;
using Vanessave.Shared.Utils;

namespace Vanessave.Desktop.Services;

public class SettingsProvider
{
    public VanessaveSettings Settings { get; private set; } = null!;

    private const string SettingsFileName = "Settings.json";
    private static FileInfo SettingsFile { get; } = new(Path.Combine(Environment.CurrentDirectory, SettingsFileName));

    private readonly ILogger<SettingsProvider> _logger;

    public SettingsProvider(ILogger<SettingsProvider> logger)
    {
        _logger = logger;

        Load();
    }

    public void Save(string? propertyName = null)
    {
        if (propertyName is not null)
        {
            _logger.LogInformation("Save triggered from property change: {Property}", propertyName);
        }
        else
        {
            _logger.LogInformation("Save triggered manually");
        }

        using var destination = SettingsFile.Create();

        JsonSerializer.Serialize(destination, Settings, JsonUtils.PrettifyOptions);
    }

    private void Load()
    {
        if (SettingsFile.Exists)
        {
            _logger.LogInformation("Loading existing settings");

            using var settingsFile = SettingsFile.OpenRead();

            Settings = JsonSerializer.Deserialize<VanessaveSettings>(settingsFile)!;
        }
        else
        {
            _logger.LogInformation("Initializing new settings");

            Settings = new VanessaveSettings();

            Save();
        }

        Settings.PropertyChanged += (_, e) => Save(e.PropertyName);
    }
}