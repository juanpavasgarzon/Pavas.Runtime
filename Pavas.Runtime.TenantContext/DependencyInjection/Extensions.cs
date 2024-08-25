using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Pavas.Patterns.Context.DependencyInjection;

namespace Pavas.Runtime.TenantContext.DependencyInjection;

public static class Extensions
{
    public static void AddTenantContext(this IServiceCollection services, List<Tenant> tenants)
    {
        services.AddSingleton(tenants);
        services.AddScopedContext<TenantContext>();
    }

    public static void AddTenantContext(
        this IServiceCollection services,
        Func<IServiceProvider, List<Tenant>> initializer)
    {
        var serviceProviderFactory = new DefaultServiceProviderFactory();
        var serviceProvider = serviceProviderFactory.CreateServiceProvider(services);
        var tenants = initializer(serviceProvider);

        services.AddSingleton(tenants);
        services.AddScopedContext<TenantContext>();
    }

    public static void UseTenantContextMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<TenantContextMiddleware>();
    }
}