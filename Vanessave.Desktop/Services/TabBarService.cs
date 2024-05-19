using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using MudBlazor;
using Vanessave.Desktop.Components.Pages;
using Vanessave.Desktop.Models;
using Vanessave.Desktop.Utils.Extensions;

namespace Vanessave.Desktop.Services;

public class TabBarService
{
    public const int HomeIndex = 0;

    public IEnumerable<TabView> TabViews => _tabViews;

    private int _activeTabIndex;

    public int ActiveIndex
    {
        get => _activeTabIndex;
        set
        {
            if (value != _activeTabIndex)
            {
                _previousTabsHistory.Push(_activeTabIndex);

                _activeTabIndex = value;

                TabBarUpdated?.Invoke();
            }
        }
    }

    public bool CanNavigateBack => _previousTabsHistory.Count > 0;
    public bool CanNavigateForward => _nextTabsHistory.Count > 0;

    public event Action? TabBarUpdated;

    private readonly ILogger<TabBarService> _logger;
    private readonly List<TabView> _tabViews;
    private readonly Stack<int> _previousTabsHistory;
    private readonly Stack<int> _nextTabsHistory;

    public TabBarService(ILogger<TabBarService> logger)
    {
        _logger = logger;

        _tabViews = new List<TabView>();
        _previousTabsHistory = new Stack<int>();
        _nextTabsHistory = new Stack<int>();

        AddDefaultTabs();
    }

    private void AddDefaultTabs()
    {
        // HomePage tab
        _tabViews.Add(new TabView(
            "Home",
            builder => builder.AddSimpleComponent<HomePage>(),
            closeable: false,
            icon: Icons.Material.Filled.Home
        ));

        // NamedSaves tab
        _tabViews.Add(new TabView(
            "Named Saves",
            builder => builder.AddSimpleComponent<NamedSavesPage>(),
            closeable: false,
            icon: Icons.Material.Filled.Class
        ));
    }

    public void NavigateBack()
    {
        if (_previousTabsHistory.Count > 0)
        {
            _nextTabsHistory.Push(_activeTabIndex);
            _activeTabIndex = _previousTabsHistory.Pop();

            TabBarUpdated?.Invoke();
        }
    }

    public void NavigateForward()
    {
        if (_nextTabsHistory.Count > 0)
        {
            _previousTabsHistory.Push(_activeTabIndex);
            _activeTabIndex = _nextTabsHistory.Pop();

            TabBarUpdated?.Invoke();
        }
    }

    public void NavigateHome()
    {
        _activeTabIndex = HomeIndex;

        _previousTabsHistory.Clear();
        _nextTabsHistory.Clear();

        TabBarUpdated?.Invoke();
    }

    public void Close(TabView tabView)
    {
        var tabIndex = _tabViews.IndexOf(tabView);

        if (tabIndex < 0)
        {
            return;
        }

        // Move to home if the current tab is this one
        if (_activeTabIndex == tabIndex)
        {
            _activeTabIndex = 0;
        }

        _tabViews.Remove(tabView);

        // Clear navigation history
        _previousTabsHistory.Clear();
        _nextTabsHistory.Clear();

        TabBarUpdated?.Invoke();

        _logger.LogInformation("Tab closed: {Name}", tabView.Name);
    }

    public void Open(TabView tabView)
    {
        if (!_tabViews.Contains(tabView))
        {
            _tabViews.Add(tabView);
        }

        ActiveIndex = _tabViews.IndexOf(tabView);

        _logger.LogInformation("Tab opened: {Name}", tabView.Name);
    }
}