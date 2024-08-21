using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Pavas.Patterns.Context.DependencyInjection;

namespace Pavas.Runtime.TraceContext.DependencyInjection;

public static class Extensions
{
    public static void AddTraceContext(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddContext<TraceContext>(ServiceLifetime.Scoped);
    }

    public static void AddTraceContextMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<TraceContextMiddleware>();
    }
}