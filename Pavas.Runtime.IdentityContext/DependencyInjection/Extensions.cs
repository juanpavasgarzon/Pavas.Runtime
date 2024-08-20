using Microsoft.Extensions.DependencyInjection;
using Pavas.Patterns.Context.DependencyInjection;

namespace Pavas.Runtime.IdentityContext.DependencyInjection;

public static class Extensions
{
    public static void AddIdentityContext(IServiceCollection serviceCollection)
    {
        serviceCollection.AddContext<IdentityContext>(ServiceLifetime.Scoped);
    }
}