# Pavas.Runtime.ApplicationContext

**Pavas.Runtime.ApplicationContext** is a library designed to manage the application context in terms of its name,
version, build mode, environment, and other key configurations. This library is useful for standardizing and
centralizing application configuration information, making it easier to access and manipulate during the program's
execution.

## Features

- **Centralized Configuration**: Provides an `ApplicationContext` class that encapsulates all relevant information about
  the application.
- **Easy Integration**: Easily integrates with ASP.NET Core via dependency injection.

## Installation

To use this library, it must be included in the project. This is usually done through dependency injection.

## Usage

### Configuring the Application Context

1. Define an application context at the start of the project:

    ```csharp
    var applicationContext = new ApplicationContext
    {
        ApplicationName = "Test",
        ApplicationVersion = new Version("1.0.0"),
        BuildMode = ApplicationBuildMode.Release,
        Environment = ApplicationEnvironment.Debug,
        BaseUrl = "api/v1"
    };
    ```

2. Inject the context into the service during the application's service configuration:

    ```csharp
    builder.Services.AddApplicationContext(applicationContext);
    ```

## Contribution

This is a project under continuous development. If you wish to contribute, please fork the repository, create a new
branch, and submit a pull request.

## License

This project is licensed under the terms of the MIT License.
