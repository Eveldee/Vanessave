using Microsoft.AspNetCore.Components;

namespace Vanessave.Desktop.Models;

public record TabView(
    string Name,
    RenderFragment Content,
    bool Closeable = false,
    string? Icon = null,
    string? Workspace = null
);