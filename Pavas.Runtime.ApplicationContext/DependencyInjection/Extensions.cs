using Microsoft.Extensions.DependencyInjection;
using Pavas.Patterns.Context.DependencyInjection;

namespace Pavas.Runtime.ApplicationContext.DependencyInjection;

public static class Extensions
{
    public static void AddApplicationContext(IServiceCollection serviceCollection)
    {
        serviceCollection.AddContext<ApplicationContext>(ServiceLifetime.Singleton);
        serviceCollection.AddHostedService<ApplicationContextHostedService>();
    }
}