using Microsoft.Extensions.DependencyInjection;
using Pavas.Patterns.Context.DependencyInjection;

namespace Pavas.Runtime.MemoryContext.DependencyInjection;

public static class Extensions
{
    public static void AddMemoryContext(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingletonContext(new MemoryContext());
    }
}