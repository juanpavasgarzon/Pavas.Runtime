using Microsoft.Extensions.DependencyInjection;
using Pavas.Patterns.Outbox.Contracts;
using Pavas.Runtime.Outbox.Contracts;

namespace Pavas.Runtime.Outbox.DependencyInjection;

public static class Extensions
{
    public static void AddOutbox<TOutboxRepository>(
        this IServiceCollection services,
        Action<OutboxOptions> configure
    ) where TOutboxRepository : class, IOutboxRepository
    {
        var options = OutboxOptions.Default;
        configure.Invoke(options);
        services.AddSingleton<IOutboxOptions, OutboxOptions>();
        services.AddSingleton<IOutboxRepository, TOutboxRepository>();
        services.AddSingleton<IPipelineFactory, PipelineFactory>();
        services.AddSingleton<IOutboxProcessor, OutboxProcessor>();
        services.AddHostedService<OutboxWorker>();
    }
}