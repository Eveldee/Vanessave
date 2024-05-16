using Microsoft.Extensions.Hosting;
using Vanessave.Desktop.Utils.Extensions;
using Vanessave.Shared.Utils.Extensions;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddVanessaveServices();

// Photino blazor in generic host
builder.UsePhotinoBlazorLifetime();

var host = builder.Build();

host.Run();