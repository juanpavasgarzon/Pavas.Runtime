namespace Pavas.Runtime.Outbox.Contracts;

public interface IOutboxProcessor
{
    Task ProcessAsync(CancellationToken cancellationToken);
}