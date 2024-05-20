namespace Vanessave.Desktop.Models;

public record Workspace
{
    public string Name { get; set; }
    public string Path { get; }

    public Workspace(string name, string path)
    {
        Name = name;
        Path = path;
    }
}