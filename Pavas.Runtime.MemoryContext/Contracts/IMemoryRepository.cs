namespace Pavas.Runtime.MemoryContext.Contracts;

public interface IMemoryRepository
{
    public TValue? Get<TKey, TValue>(TKey id) where TKey : notnull;
    public void Add<TKey, TValue>(TKey id, TValue value) where TKey : notnull where TValue : notnull;
    public void Remove<TKey>(TKey id) where TKey : notnull;
}