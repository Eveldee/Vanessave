using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Vanessave.Desktop.Utils.Extensions;

public static class RenderTreeBuilderExtensions
{
    public static void AddSimpleComponent<T>(this RenderTreeBuilder builder) where T : IComponent
    {
        builder.OpenComponent<T>(0);

        builder.CloseComponent();
    }
}