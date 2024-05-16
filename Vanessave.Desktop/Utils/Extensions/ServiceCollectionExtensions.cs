using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;
using Vanessave.Desktop.Services;

namespace Vanessave.Desktop.Utils.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHostedPhotinoBlazorServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHostedService<PhotinoBlazorService>();

        return serviceCollection;
    }
}