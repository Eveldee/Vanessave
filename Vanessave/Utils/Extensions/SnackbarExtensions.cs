using MudBlazor;

namespace Vanessave.Utils.Extensions;

public static class SnackbarExtensions
{
    public static void AddError(this ISnackbar snackbar, string message)
    {
        snackbar.Add(message, Severity.Error, options => options.DuplicatesBehavior = SnackbarDuplicatesBehavior.Allow);
    }
}