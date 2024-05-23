using MudBlazor;

namespace Vanessave.Shared.Utils.Extensions;

public static class SnackbarExtensions
{
    public static void AddError(this ISnackbar snackbar, string message)
    {
        snackbar.Add(message, Severity.Error, options => options.DuplicatesBehavior = SnackbarDuplicatesBehavior.Allow);
    }

    public static void AddInfo(this ISnackbar snackbar, string message)
    {
        snackbar.Add(message, Severity.Info, options => options.DuplicatesBehavior = SnackbarDuplicatesBehavior.Allow);
    }

    public static void AddSuccess(this ISnackbar snackbar, string message)
    {
        snackbar.Add(message, Severity.Success, options => options.DuplicatesBehavior = SnackbarDuplicatesBehavior.Allow);
    }

    public static void AddWarning(this ISnackbar snackbar, string message)
    {
        snackbar.Add(message, Severity.Warning, options => options.DuplicatesBehavior = SnackbarDuplicatesBehavior.Allow);
    }
}