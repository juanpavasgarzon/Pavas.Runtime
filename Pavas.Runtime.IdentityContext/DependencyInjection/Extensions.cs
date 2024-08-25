using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Pavas.Patterns.Context.DependencyInjection;

namespace Pavas.Runtime.IdentityContext.DependencyInjection;

public static class Extensions
{
    public static void AddIdentityContext(this IServiceCollection services)
    {
        services.AddScopedContext<IdentityContext>();
    }

    public static void UseIdentityContextMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<IdentityContextMiddleware>();
    }
}