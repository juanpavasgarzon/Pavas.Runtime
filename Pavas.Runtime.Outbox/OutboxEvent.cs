using Pavas.Patterns.Outbox.Contracts;

namespace Pavas.Runtime.Outbox;

public class OutboxEvent : IOutboxEvent
{
    public int Id { get; init; }
    public string EventType { get; set; } = string.Empty;
    public string Payload { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? PublishedAt { get; set; }
    public DateTime? FailedAt { get; set; }
}