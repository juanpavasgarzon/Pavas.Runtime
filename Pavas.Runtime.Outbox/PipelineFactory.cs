using Pavas.Runtime.Outbox.Contracts;
using Polly;
using Polly.Retry;

namespace Pavas.Runtime.Outbox;

public class PipelineFactory(IOutboxOptions options) : IPipelineFactory
{
    public ResiliencePipeline GetPipeline()
    {
        return new ResiliencePipelineBuilder().AddRetry(new RetryStrategyOptions
        {
            ShouldHandle = new PredicateBuilder().Handle<Exception>(),
            Delay = TimeSpan.FromMilliseconds(options.RetryInterval),
            MaxRetryAttempts = options.MaxRetries,
            BackoffType = DelayBackoffType.Exponential,
            MaxDelay = TimeSpan.FromMilliseconds(options.MaxDelay),
            OnRetry = args => default
        }).Build();
    }
}