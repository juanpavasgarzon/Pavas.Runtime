namespace Pavas.Runtime.MemoryContext.Contracts;

public interface IRepository
{
    public string Name { get; init; }
    public Dictionary<object, object?> Storage { get; init; }
}