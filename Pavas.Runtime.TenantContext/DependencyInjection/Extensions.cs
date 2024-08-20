using Microsoft.Extensions.DependencyInjection;
using Pavas.Patterns.Context.DependencyInjection;

namespace Pavas.Runtime.TenantContext.DependencyInjection;

public static class Extensions
{
    public static void AddTenantContext(IServiceCollection serviceCollection)
    {
        serviceCollection.AddContext<TenantContext>(ServiceLifetime.Scoped);
    }
}