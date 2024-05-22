namespace Vanessave.Shared.Utils.Extensions;

public static class EnumerableExtensions
{
    public static IEnumerable<(TItem item, int index)> WithIndex<TItem>(this IEnumerable<TItem> enumerable)
        => enumerable.Select((item, index) => (item, index));

    public static IEnumerable<(TItem item, bool first)> WithFirst<TItem>(this IEnumerable<TItem> enumerable)
    {
        var first = true;

        foreach (var item in enumerable)
        {
            yield return (item, first);

            first = false;
        }
    }
}