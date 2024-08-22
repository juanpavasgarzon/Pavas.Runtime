using Microsoft.Extensions.DependencyInjection;
using Pavas.Patterns.Context.DependencyInjection;

namespace Pavas.Runtime.ApplicationContext.DependencyInjection;

public static class Extensions
{
    public static void AddApplicationContext(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingletonContext(new ApplicationContext());
    }

    public static void AddApplicationContext(
        this IServiceCollection serviceCollection,
        ApplicationContext initialContext
    )
    {
        serviceCollection.AddSingletonContext(initialContext);
    }

    public static void AddApplicationContext(
        this IServiceCollection serviceCollection,
        Func<IServiceProvider, ApplicationContext> initializer
    )
    {
        serviceCollection.AddSingletonContext(initializer);
    }
}