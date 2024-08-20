using Microsoft.Extensions.DependencyInjection;
using Pavas.Patterns.Context.DependencyInjection;

namespace Pavas.Runtime.MemoryContext.DependencyInjection;

public static class Extensions
{
    public static void AddMemoryContext(IServiceCollection serviceCollection)
    {
        serviceCollection.AddContext<MemoryContext>(ServiceLifetime.Singleton);
    }
}