using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Pavas.Patterns.Context.DependencyInjection;

namespace Pavas.Runtime.TraceContext.DependencyInjection;

public static class Extensions
{
    public static void AddTraceContext(this IServiceCollection services)
    {
        services.AddScopedContext<TraceContext>();
    }

    public static void UseTraceContextMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<TraceContextMiddleware>();
    }
}