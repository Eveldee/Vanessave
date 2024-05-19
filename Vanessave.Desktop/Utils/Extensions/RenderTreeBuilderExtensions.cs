using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Vanessave.Desktop.Utils.Extensions;

public static class RenderTreeBuilderExtensions
{
    public static void AddSimpleComponent<TComponent>(this RenderTreeBuilder builder) where TComponent : IComponent
    {
        builder.OpenComponent<TComponent>(0);

        builder.CloseComponent();
    }

    public static void AddSimpleComponent<TComponent, TParameter>(this RenderTreeBuilder builder, TParameter parameter) where TComponent : IComponent
    {
        builder.OpenComponent<TComponent>(0);

        builder.AddAttribute(0, typeof(TParameter).Name, parameter);

        builder.CloseComponent();
    }
}