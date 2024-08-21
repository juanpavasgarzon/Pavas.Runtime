using Microsoft.Extensions.DependencyInjection;
using Pavas.Patterns.Context.Contracts;
using Pavas.Patterns.Context.DependencyInjection;

namespace Pavas.Runtime.ApplicationContext.DependencyInjection;

public static class Extensions
{
    public static void AddApplicationContext(
        this IServiceCollection serviceCollection,
        ApplicationContext? initialContext = null
    )
    {
        serviceCollection.AddContext<ApplicationContext>(ServiceLifetime.Singleton);
        serviceCollection.AddHostedService(provider =>
        {
            var factory = provider.GetRequiredService<IContextFactory<ApplicationContext>>();
            return new ApplicationContextHostedService(factory, initialContext);
        });
    }
}