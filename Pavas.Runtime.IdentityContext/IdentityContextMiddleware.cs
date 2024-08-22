using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Pavas.Patterns.Context.Contracts;

namespace Pavas.Runtime.IdentityContext;

public sealed class IdentityContextMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context, IContextFactory<IdentityContext> contextFactory)
    {
        var identityContext = CreateIdentityContext(context);
        contextFactory.Construct(identityContext);
        await next(context);
        contextFactory.Destruct();
    }

    private static IdentityContext CreateIdentityContext(HttpContext context) => new()
    {
        Identifier = ClaimValue(context.User, ClaimTypes.NameIdentifier),
        Username = Name(context.User),
        Email = ClaimValue(context.User, ClaimTypes.Email),
        Country = ClaimValue(context.User, ClaimTypes.Country),
        Gender = ClaimValue(context.User, ClaimTypes.Gender),
        PostalCode = ClaimValue(context.User, ClaimTypes.PostalCode),
        AuthenticationType = AuthenticationType(context.User),
        IsAuthenticated = IsAuthenticated(context.User),
        IpAddress = IpAddress(context.Connection),
        Roles = context.User.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList(),
        Claims = context.User.Claims.ToList(),
    };

    private static string ClaimValue(ClaimsPrincipal claimsPrincipal, string type)
    {
        return claimsPrincipal.FindFirst(type)?.Value ?? string.Empty;
    }

    private static string AuthenticationType(ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.Identity?.AuthenticationType ?? string.Empty;
    }

    private static bool IsAuthenticated(ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.Identity?.IsAuthenticated ?? false;
    }

    private static string Name(ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.Identity?.Name ?? "Anonymous";
    }

    private static string IpAddress(ConnectionInfo info)
    {
        return info.RemoteIpAddress?.ToString() ?? string.Empty;
    }
}