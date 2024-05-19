using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Vanessave.Desktop.Services;

namespace Vanessave.Desktop.Utils.Extensions;

public static class HostApplicationBuilderExtensions
{
    public static IHostApplicationBuilder UsePhotinoBlazorLifetime(this IHostApplicationBuilder builder)
    {
        builder.Services.AddHostedPhotinoBlazorServices();
        builder.Services.AddSingleton(new ServiceCollectionInjector(builder.Services));

        return builder;
    }
}