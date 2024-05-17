using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Vanessave.Desktop.Models;

namespace Vanessave.Desktop.Services;

public class WorkspacesService
{
    public IEnumerable<Workspace> Workspaces => _workspaces;

    private readonly IList<Workspace> _workspaces;

    private readonly ILogger<WorkspacesService> _logger;

    public WorkspacesService(ILogger<WorkspacesService> logger)
    {
        _logger = logger;

        _workspaces = new List<Workspace>();
    }

    public void Open(Workspace workspace)
    {
        _workspaces.Add(workspace);
    }

    public void Close(Workspace workspace)
    {
        if (_workspaces.Remove(workspace))
        {
            _logger.LogInformation("Closed workspace: {Workspace}", workspace);
        }
    }
}