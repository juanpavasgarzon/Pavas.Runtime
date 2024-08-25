using Microsoft.Extensions.DependencyInjection;
using Pavas.Patterns.Context.DependencyInjection;

namespace Pavas.Runtime.ApplicationContext.DependencyInjection;

public static class Extensions
{
    public static void AddApplicationContext(this IServiceCollection services)
    {
        services.AddSingletonContext(new ApplicationContext());
    }

    public static void AddApplicationContext(
        this IServiceCollection services,
        ApplicationContext initialContext
    )
    {
        services.AddSingletonContext(initialContext);
    }

    public static void AddApplicationContext(
        this IServiceCollection services,
        Func<IServiceProvider, ApplicationContext> initializer
    )
    {
        services.AddSingletonContext(initializer);
    }
}