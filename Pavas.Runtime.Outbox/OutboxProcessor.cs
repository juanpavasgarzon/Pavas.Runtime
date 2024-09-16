using Pavas.Patterns.Outbox.Contracts;
using Pavas.Runtime.Outbox.Contracts;

namespace Pavas.Runtime.Outbox;

public class OutboxProcessor(
    IPipelineFactory pipelineFactory,
    IOutboxRepository repository,
    IOutboxOptions options
) : IOutboxProcessor
{
    public async Task ProcessAsync(CancellationToken cancellationToken)
    {
        var pipeline = pipelineFactory.GetPipeline();
        var events = await repository.GetPendingEventsAsync<IOutboxEvent>(cancellationToken);
        foreach (var @event in events)
        {
            await pipeline.ExecuteAsync(async token => { await ProcessEvent(@event, token); }, cancellationToken);
            Thread.Sleep(options.DelayBetweenEvents);
        }
    }

    private async Task ProcessEvent(IOutboxEvent @event, CancellationToken cancellationToken)
    {
        try
        {
            await repository.SetEventAsPublishedAsync(@event, cancellationToken);
        }
        catch (Exception)
        {
            await repository.SetEventAsFailedAsync(@event, cancellationToken);
        }
    }
}