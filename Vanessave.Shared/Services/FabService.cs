using Microsoft.AspNetCore.Components;
using MudBlazor;
using Vanessave.Shared.Models;

namespace Vanessave.Shared.Services;

public class FabService
{
    public event Action? FabsUpdated;

    public IEnumerable<FabInstance> FabInstances => _fabInstances;

    private readonly List<FabInstance> _fabInstances;

    public FabService()
    {
        _fabInstances = new List<FabInstance>();
    }

    public FabInstance Add(string tooltip, string icon, Color color, Size size, EventCallback clickHandler)
    {
        var fabInstance = new FabInstance(this, tooltip, icon, color, size, clickHandler);

        _fabInstances.Add(fabInstance);

        FabsUpdated?.Invoke();

        return fabInstance;
    }
    public FabInstance Add(string tooltip, string icon, Color color, EventCallback clickHandler)
    {
        return Add(tooltip, icon, color, Size.Large, clickHandler);
    }

    public void Remove(FabInstance fabInstance)
    {
        _fabInstances.Remove(fabInstance);

        FabsUpdated?.Invoke();
    }
}