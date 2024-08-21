using Microsoft.Extensions.DependencyInjection;
using Pavas.Patterns.Context.DependencyInjection;

namespace Pavas.Runtime.RequestContext.DependencyInjection;

public static class Extensions
{
    public static void AddRequestContext(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddContext<RequestContext>(ServiceLifetime.Scoped);
    }
}