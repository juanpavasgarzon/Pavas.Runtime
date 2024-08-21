using Microsoft.Extensions.Hosting;
using Pavas.Patterns.Context.Contracts;

namespace Pavas.Runtime.MemoryContext.DependencyInjection;

internal sealed class MemoryContextHostedService(IContextFactory<MemoryContext> contextFactory) : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        contextFactory.Construct(new MemoryContext());
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        contextFactory.Destruct();
        return Task.CompletedTask;
    }
}