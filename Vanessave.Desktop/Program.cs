using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using Vanessave.Desktop.Services;
using Vanessave.Desktop.Utils.Extensions;
using Vanessave.Shared.Utils.Extensions;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddVanessaveServices();

builder.Services.AddHotKeys2();

builder.Services.AddSingleton<TabBarService>();
builder.Services.AddSingleton<WorkspacesService>();

// Photino blazor in generic host
builder.UsePhotinoBlazorLifetime();

var host = builder.Build();

host.Run();