# Pavas.Runtime.MemoryContext

**Pavas.Runtime.MemoryContext** is a library designed to manage in-memory contexts for caching or quick data retrieval
operations. This library is particularly useful for applications that require fast access to certain datasets or need to
maintain a temporary state in memory.

## Features

- **In-Memory Data Storage**: Provides a simple interface for storing and retrieving data in memory.
- **Context Management**: Allows the creation of multiple contexts for different datasets.
- **Dependency Injection Integration**: Easily integrates with ASP.NET Core's dependency injection.

## Installation

To use this library, include it in your project through dependency injection.

## Usage

### Setting Up the Memory Context

1. Define the memory repositories during the project initialization:

    ```csharp
    string[] repositories = [
        "Name1",
        "Name2",
        ...etc
    ];
    
    // or use Repository entity, provides name and default data

    List<Repository> repositories = [
        new Repository("Name1", [])
        new Repository("Name2", [])
    ];
    ```


2. Inject the context into the service during the application service configuration:

    ```csharp
    builder.Services.AddMemoryContext(repositories);
    ```

### Using the Middleware

The `MemoryContextMiddleware` can be used to manage memory contexts throughout the lifecycle of the application:

```csharp
app.UseMemoryContextMiddleware();
```

This middleware will ensure that the memory context is properly initialized and disposed of during each request.

## Contribution

This project is under continuous development. If you wish to contribute, please fork the repository, create a new
branch, and submit a pull request.

## License

This project is licensed under the terms of the MIT License.
