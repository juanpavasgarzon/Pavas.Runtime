using Pavas.Runtime.MemoryContext.Contracts;

namespace Pavas.Runtime.MemoryContext;

internal sealed class MemoryRepository : IMemoryRepository
{
    private readonly Dictionary<object, object?> _data = new();

    public MemoryRepository()
    {
    }

    public MemoryRepository(Dictionary<object, object?> data)
    {
        _data = data;
    }

    public TValue? Get<TKey, TValue>(TKey id) where TKey : notnull
    {
        _data.TryGetValue(id, out var value);
        return (TValue?)value;
    }

    public void Add<TKey, TValue>(TKey id, TValue value) where TKey : notnull where TValue : notnull
    {
        _data.Add(id, value);
    }

    public void Remove<TKey>(TKey id) where TKey : notnull
    {
        _data.Remove(id);
    }
}