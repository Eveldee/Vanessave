using System;
using System.Collections.Generic;
using System.IO;
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

    public int ActiveIndex
    {
        get => _tabViews.IndexOf(ActiveTab);
        set => ActiveTab = _tabViews[value];
    }

    private TabView _activeTab = null!;
    public TabView ActiveTab
    {
        get => _activeTab;
        set
        {
            if (value != _activeTab)
            {
                _previousTabsHistory.Push(_activeTab);
                _nextTabsHistory.Clear();

                _activeTab = value;

                TabBarUpdated?.Invoke();
            }
        }
    }

    public bool CanNavigateBack => _previousTabsHistory.Count > 0;
    public bool CanNavigateForward => _nextTabsHistory.Count > 0;

    public event Action? TabBarUpdated;

    private readonly ILogger<TabBarService> _logger;
    private readonly List<TabView> _tabViews;
    private Stack<TabView> _previousTabsHistory;
    private Stack<TabView> _nextTabsHistory;

    public TabBarService(ILogger<TabBarService> logger)
    {
        _logger = logger;

        _tabViews = new List<TabView>();
        _previousTabsHistory = new Stack<TabView>();
        _nextTabsHistory = new Stack<TabView>();

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
            "Archives",
            builder => builder.AddSimpleComponent<ArchivesPage>(),
            closeable: false,
            icon: Icons.Material.Filled.Archive
        ));

        // Set home as active tab
        _activeTab = _tabViews[HomeIndex];
    }

    public void NavigateBack()
    {
        NavigateBack(true);
    }
    private void NavigateBack(bool updateHistory)
    {
        if (_previousTabsHistory.Count > 0)
        {
            if (updateHistory)
            {
                _nextTabsHistory.Push(_activeTab);
            }

            _activeTab = _previousTabsHistory.Pop();

            TabBarUpdated?.Invoke();
        }
    }

    public void NavigateForward()
    {
        if (_nextTabsHistory.Count > 0)
        {
            _previousTabsHistory.Push(_activeTab);
            _activeTab = _nextTabsHistory.Pop();

            TabBarUpdated?.Invoke();
        }
    }

    public void NavigateHome()
    {
        _activeTab = _tabViews[HomeIndex];

        _previousTabsHistory.Clear();
        _nextTabsHistory.Clear();

        TabBarUpdated?.Invoke();
    }

    public void Close(TabView toRemove)
    {
        if (!_tabViews.Remove(toRemove))
        {
            return;
        }

        // Remove this tab from navigation history
        _previousTabsHistory = new Stack<TabView>(_previousTabsHistory.Where(tab => tab != toRemove).Reverse());
        _nextTabsHistory = new Stack<TabView>(_nextTabsHistory.Where(tab => tab != toRemove).Reverse());

        // If deleted tab is current, we need to move to previous or home
        if (toRemove == _activeTab)
        {
            if (_previousTabsHistory.Count > 0)
            {
                NavigateBack(false);
            }
            else
            {
                NavigateHome();
            }
        }
        else
        {
            TabBarUpdated?.Invoke();
        }

        _logger.LogInformation("Tab closed: {Name}", toRemove.Name);
    }

    public void Open(TabView tabView)
    {
        if (!_tabViews.Contains(tabView))
        {
            _tabViews.Add(tabView);
        }

        ActiveTab = tabView;

        _logger.LogInformation("Tab opened: {Name}", tabView.Name);
    }

    public void OpenWorkspace(Workspace workspace)
    {
        Open(new TabView(
            name: workspace.Name,
            content: builder => builder.AddSimpleComponent<WorkspacePage, Workspace>(workspace),
            closeable: true,
            icon: Icons.Material.Filled.Dashboard,
            caption: "Install"
        ));
    }

    public void OpenSave(SaveInfo saveInfo)
    {
        Open(new TabView(
            name: saveInfo.SaveName,
            content: builder => builder.AddSimpleComponent<EditSavePage, SaveInfo>(saveInfo),
            closeable: true,
            icon: Icons.Material.Filled.Edit,
            caption: "Save"
        ));
    }

    public void OpenSettings(FileInfo fileInfo)
    {
        Open(new TabView(
            name: fileInfo.Name,
            content: builder => builder.AddSimpleComponent<EditSystemSettingsPage, FileInfo>(fileInfo),
            closeable: true,
            icon: Icons.Material.Filled.Settings,
            caption: "Settings"
        ));
    }
}