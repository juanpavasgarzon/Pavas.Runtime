using Microsoft.AspNetCore.Http;
using Pavas.Patterns.Context.Contracts;

namespace Pavas.Runtime.TenantContext;

public sealed class TenantContextMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context, IContextFactory<TenantContext> contextFactory, List<Tenant> tenants)
    {
        var tenantContext = CreateTenantContext(context.Request.Headers, tenants);
        contextFactory.Construct(tenantContext);
        await next(context);
        contextFactory.Destruct();
    }

    private static TenantContext CreateTenantContext(IHeaderDictionary headers, List<Tenant> tenants)
    {
        _ = headers.TryGetValue("X-Tenant-ID", out var tenantId);
        var tenant = tenants.Find(item => item.Id == tenantId.FirstOrDefault());

        return new TenantContext
        {
            TenantId = tenant?.Id ?? string.Empty,
            TenantName = tenant?.Name ?? string.Empty,
            Connection = tenant?.Connection ?? string.Empty,
        };
    }
}