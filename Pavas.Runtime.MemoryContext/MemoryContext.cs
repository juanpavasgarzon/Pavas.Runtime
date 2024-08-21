using Pavas.Runtime.MemoryContext.Contracts;

namespace Pavas.Runtime.MemoryContext;

public sealed class MemoryContext
{
    private readonly Dictionary<string, IMemoryRepository> _repositories = new();

    public IMemoryRepository? GetRepository(string name)
    {
        _repositories.TryGetValue(name, out var repository);
        return repository;
    }

    public IMemoryRepository AddRepository(string name)
    {
        var repository = new MemoryRepository();
        _repositories.Add(name, repository);
        return repository;
    }

    public void RemoveRepository(string name)
    {
        _repositories.Remove(name);
    }
}