using System;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic.CompilerServices;

namespace Vanessave.Desktop.Models;

public class TabView(
    string name,
    RenderFragment content,
    bool closeable = false,
    string? icon = null,
    string? caption = null
) : IEquatable<TabView>
{
    public string Name { get; } = name;

    public RenderFragment Content { get; } = content;

    public bool Closeable { get; } = closeable;

    public string? Icon { get; } = icon;

    public string? Caption { get; } = caption;

    public static bool operator==(TabView left, TabView right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(TabView left, TabView right)
    {
        return !(left == right);
    }

    public bool Equals(TabView? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return Name == other.Name
            && Closeable == other.Closeable
            && Icon == other.Icon
            && Caption == other.Caption;
    }

    public override bool Equals(object? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return other is TabView tabView && Equals(tabView);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Closeable, Icon, Caption);
    }
}
