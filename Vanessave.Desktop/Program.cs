using Microsoft.Extensions.Hosting;
using Vanessave.Desktop.Utils.Extensions;

var builder = Host.CreateApplicationBuilder(args);

// Photino blazor in generic host
builder.UsePhotinoBlazorLifetime();

var host = builder.Build();

host.Run();