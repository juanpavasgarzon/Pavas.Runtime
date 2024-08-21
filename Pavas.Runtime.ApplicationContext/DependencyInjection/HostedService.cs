using Microsoft.Extensions.Hosting;
using Pavas.Patterns.Context.Contracts;

namespace Pavas.Runtime.ApplicationContext.DependencyInjection;

internal sealed class ApplicationContextHostedService(
    IContextFactory<ApplicationContext> contextFactory
) : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        contextFactory.Construct(new ApplicationContext());
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        contextFactory.Destruct();
        return Task.CompletedTask;
    }
}