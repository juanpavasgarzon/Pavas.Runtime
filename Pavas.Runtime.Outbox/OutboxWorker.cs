using Microsoft.Extensions.Hosting;
using Pavas.Runtime.Outbox.Contracts;

namespace Pavas.Runtime.Outbox;

public class OutboxWorker(
    IPipelineFactory pipelineFactory,
    IOutboxProcessor outboxProcessor,
    IOutboxOptions options
) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var pipeline = pipelineFactory.GetPipeline();
            await pipeline.ExecuteAsync(async token => { await outboxProcessor.ProcessAsync(token); }, stoppingToken);
            await Task.Delay(options.DelayBetweenBatches, stoppingToken);
        }
    }
}