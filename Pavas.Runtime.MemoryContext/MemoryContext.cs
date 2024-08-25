using Pavas.Runtime.MemoryContext.Contracts;

namespace Pavas.Runtime.MemoryContext;

public sealed class MemoryContext
{
    private readonly Dictionary<string, IMemoryRepository> _repositories = new();

    public MemoryContext()
    {
        _repositories = new Dictionary<string, IMemoryRepository>();
    }

    public MemoryContext(List<Repository> repositories)
    {
        foreach (var repository in repositories)
        {
            _repositories.Add(repository.Name, new MemoryRepository(repository.Storage));
        }
    }

    public MemoryContext(string[] repositoryNames)
    {
        foreach (var repositoryName in repositoryNames)
        {
            _repositories.Add(repositoryName, new MemoryRepository());
        }
    }

    public IMemoryRepository? GetRepository(string name)
    {
        _repositories.TryGetValue(name, out var repository);
        return repository;
    }

    public IMemoryRepository AddRepository(Repository repository)
    {
        var memoryRepository = new MemoryRepository(repository.Storage);
        _repositories.Add(repository.Name, memoryRepository);
        return memoryRepository;
    }

    public IMemoryRepository AddRepository(string repositoryName)
    {
        var memoryRepository = new MemoryRepository();
        _repositories.Add(repositoryName, memoryRepository);
        return memoryRepository;
    }

    public void RemoveRepository(string name)
    {
        _repositories.Remove(name);
    }
}