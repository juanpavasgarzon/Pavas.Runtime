using Microsoft.AspNetCore.Http;
using Pavas.Patterns.Context.Contracts;

namespace Pavas.Runtime.TraceContext;

public sealed class TraceContextMiddleware(IContextFactory<TraceContext> contextFactory) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var traceContext = CreateTraceContext(context);
        contextFactory.Construct(traceContext);
        await next(context);
        contextFactory.Destruct();
    }

    private static TraceContext CreateTraceContext(HttpContext context) => new()
    {
        RequestId = context.TraceIdentifier,
        CorrelationId = CorrelationId(context.Request.Headers),
        RequestStartTime = DateTime.UtcNow,
        UserAgent = UserAgent(context.Request.Headers),
        ClientIp = context.Connection.RemoteIpAddress?.ToString() ?? "Unknown"
    };

    private static string UserAgent(IHeaderDictionary headers)
    {
        if (headers.TryGetValue("User-Agent", out var userAgent))
            return userAgent;

        return "Unknown";
    }

    private static string CorrelationId(IHeaderDictionary headers)
    {
        if (headers.TryGetValue("X-Correlation-ID", out var correlationId))
            return correlationId;

        return Guid.NewGuid().ToString();
    }
}