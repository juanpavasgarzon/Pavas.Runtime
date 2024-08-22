using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Pavas.Patterns.Context.DependencyInjection;

namespace Pavas.Runtime.IdentityContext.DependencyInjection;

public static class Extensions
{
    public static void AddIdentityContext(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScopedContext<IdentityContext>();
    }

    public static void AddIdentityContextMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<IdentityContextMiddleware>();
    }
}