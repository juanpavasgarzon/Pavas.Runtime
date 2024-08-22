using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Pavas.Patterns.Context.DependencyInjection;

namespace Pavas.Runtime.TenantContext.DependencyInjection;

public static class Extensions
{
    public static void AddTenantContext(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScopedContext<TenantContext>();
    }

    public static void AddIdentityContextMiddleware(this IApplicationBuilder app, List<Tenant> tenants)
    {
        app.UseMiddleware<TenantContextMiddleware>(tenants);
    }
}