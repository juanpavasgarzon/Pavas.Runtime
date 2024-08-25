using Pavas.Runtime.MemoryContext.Contracts;

namespace Pavas.Runtime.MemoryContext;

public record Repository(string Name) : IRepository
{
    public Repository(string name, Dictionary<object, object?> storage) : this(name)
    {
        Storage = storage;
    }

    public Dictionary<object, object?> Storage { get; init; } = [];
}