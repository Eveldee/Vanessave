using System.Runtime.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Vanessave.Shared.Services;

namespace Vanessave.Shared.Utils.Extensions;

[UnsupportedOSPlatform("browser")]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddVanessaveServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<SaveCipherProvider>();
        serviceCollection.AddSingleton<AchievementMetadataProvider>();
        serviceCollection.AddSingleton<ValuablesMetadataProvider>();
        serviceCollection.AddSingleton<FabService>();

        return serviceCollection;
    }
}