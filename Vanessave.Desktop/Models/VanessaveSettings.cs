using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Vanessave.Desktop.Models;

public partial class VanessaveSettings : ObservableObject
{
    [ObservableProperty]
    private List<Workspace> _workspaces = [];
}