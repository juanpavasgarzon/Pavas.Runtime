using Microsoft.AspNetCore.Http;
using Pavas.Patterns.Context.Contracts;
using Pavas.Runtime.TenantContext.Exceptions;

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
        var defaultTenant = tenants.Find(tenant => tenant.IsDefault);
        if (!headers.TryGetValue("X-Tenant-ID", out var tenantId) && defaultTenant is null)
            throw new NotFoundException("X-Tenant-ID Is Required");

        var tenant = tenants.Find(item => item.Id == tenantId.FirstOrDefault());
        if (tenant is null && tenantId.Count != 0)
            throw new NotFoundException($"Tenant {tenantId} not found");

        tenant ??= defaultTenant!;

        return new TenantContext
        {
            TenantId = tenant.Id,
            TenantName = tenant.Name,
            Connection = tenant.Connection,
        };
    }
}