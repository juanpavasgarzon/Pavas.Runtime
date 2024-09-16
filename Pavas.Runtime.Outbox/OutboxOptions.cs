using Pavas.Runtime.Outbox.Contracts;

public class OutboxOptions : IOutboxOptions
{    
    public int DelayBetweenEvents { get; private set; }

    public int DelayBetweenBatches { get; private set; }

    public int RetryInterval { get; private set; }

    public int MaxRetries { get; private set; }

    public int MaxDelay { get; private set; }

    public static OutboxOptions Default => new()
    {
        DelayBetweenEvents = 10,
        DelayBetweenBatches = 1000,
        RetryInterval = 1000,
        MaxRetries = 3,
        MaxDelay = 5000
    };

    public void SetDelayBetweenEvents(int value)
    {
        DelayBetweenEvents = value;
    }

    public void SetDelayBetweenBatches(int value)
    {
        DelayBetweenBatches = value;
    }

    public void SetRetryInterval(int value)
    {
        RetryInterval = value;
    }

    public void SetMaxRetries(int value)
    {
        MaxRetries = value;
    }

    public void SetMaxDelay(int value)
    {
        MaxDelay = value;
    }
}