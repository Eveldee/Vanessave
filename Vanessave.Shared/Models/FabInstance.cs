using Microsoft.AspNetCore.Components;
using MudBlazor;
using Vanessave.Shared.Services;

namespace Vanessave.Shared.Models;

public sealed class FabInstance : IDisposable
{
    public string Tooltip { get; }
    public string Icon { get; }
    public Color Color { get; }
    public Size Size { get; }
    public EventCallback ClickHandler { get; }

    private readonly FabService _fabService;

    public FabInstance(FabService fabService, string tooltip, string icon, Color color, Size size, EventCallback clickHandler)
    {
        _fabService = fabService;
        Tooltip = tooltip;
        Icon = icon;
        Color = color;
        Size = size;
        ClickHandler = clickHandler;
    }

    public void Dispose()
    {
        _fabService.Remove(this);
    }
}