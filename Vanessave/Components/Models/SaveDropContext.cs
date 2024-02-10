using Microsoft.AspNetCore.Components.Forms;

namespace Vanessave.Components.Models;

public class SaveDropContext
{
    public event Func<IBrowserFile, Task>? OnFileDrop;

    public Task DropFile(IBrowserFile browserFile)
    {
        return OnFileDrop?.Invoke(browserFile) ?? Task.CompletedTask;
    }
}