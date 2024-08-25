using Microsoft.Extensions.DependencyInjection;
using Pavas.Patterns.Context.DependencyInjection;

namespace Pavas.Runtime.MemoryContext.DependencyInjection;

public static class Extensions
{
    public static void AddMemoryContext(this IServiceCollection services)
    {
        services.AddSingletonContext(new MemoryContext());
    }

    public static void AddMemoryContext(this IServiceCollection services, List<Repository> repositories)
    {
        services.AddSingletonContext(new MemoryContext(repositories));
    }

    public static void AddMemoryContext(this IServiceCollection services, string[] repositoryNames)
    {
        services.AddSingletonContext(new MemoryContext(repositoryNames));
    }

    public static void AddMemoryContext(
        this IServiceCollection services,
        Func<IServiceProvider, List<Repository>> initializer
    )
    {
        services.AddSingletonContext(provider =>
        {
            var repositories = initializer(provider);
            return new MemoryContext(repositories);
        });
    }

    public static void AddMemoryContext(
        this IServiceCollection services,
        Func<IServiceProvider, string[]> initializer
    )
    {
        services.AddSingletonContext(provider =>
        {
            var repositoryNames = initializer(provider);
            return new MemoryContext(repositoryNames);
        });
    }
}