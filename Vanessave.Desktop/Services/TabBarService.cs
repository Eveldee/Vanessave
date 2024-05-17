using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MudBlazor;
using Vanessave.Desktop.Components.Pages;
using Vanessave.Desktop.Models;
using Vanessave.Desktop.Utils.Extensions;

namespace Vanessave.Desktop.Services;

public class TabBarService
{
    public IEnumerable<TabView> TabViews => _tabViews;

    public int ActiveIndex { get; set; }

    public event Action? TabBarUpdated;

    private readonly ILogger<TabBarService> _logger;
    private readonly List<TabView> _tabViews;

    public TabBarService(ILogger<TabBarService> logger)
    {
        _logger = logger;

        _tabViews = new List<TabView>();

        AddDefaultTabs();
    }

    private void AddDefaultTabs()
    {
        // HomePage tab
        _tabViews.Add(new TabView(
            "Home",
            builder => builder.AddSimpleComponent<HomePage>(),
            Closeable: false,
            Icon: Icons.Material.Filled.Home
        ));

        // NamedSaves tab
        _tabViews.Add(new TabView(
            "Named Saves",
            builder => builder.AddSimpleComponent<NamedSavesPage>(),
            Closeable: false,
            Icon: Icons.Material.Filled.Class
        ));
    }

    public void Close(TabView tabView)
    {
        _tabViews.Remove(tabView);

        TabBarUpdated?.Invoke();

        _logger.LogInformation("Tab closed: {Name}", tabView.Name);
    }
}