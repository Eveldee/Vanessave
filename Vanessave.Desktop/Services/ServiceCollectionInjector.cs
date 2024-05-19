using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Vanessave.Desktop.Services;

public class ServiceCollectionInjector
{
    private readonly IList<ServiceDescriptor> _serviceDescriptors;

    public ServiceCollectionInjector(IEnumerable<ServiceDescriptor> serviceDescriptors)
    {
        _serviceDescriptors = serviceDescriptors.ToList();
    }

    public void InjectInto(IServiceCollection serviceCollection)
    {
        foreach (var serviceDescriptor in _serviceDescriptors)
        {
            serviceCollection.Add(serviceDescriptor);
        }
    }
}