namespace Pavas.Runtime.Outbox.Contracts;

public interface IOutboxOptions
{
    public int DelayBetweenEvents { get; }
    public int DelayBetweenBatches { get; }
    public int RetryInterval { get; }
    public int MaxRetries { get; }
    public int MaxDelay { get; }
}