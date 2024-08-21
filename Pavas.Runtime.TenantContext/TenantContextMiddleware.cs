using Microsoft.AspNetCore.Http;
using Pavas.Patterns.Context.Contracts;

namespace Pavas.Runtime.TenantContext;

public class TenantContextMiddleware(IContextFactory<TenantContext> contextFactory, List<Tenant> tenants) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var tenantContext = CreateTenantContext(context.Request.Headers);
        contextFactory.Construct(tenantContext);
        await next(context);
        contextFactory.Destruct();
    }

    private TenantContext CreateTenantContext(IHeaderDictionary headers)
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