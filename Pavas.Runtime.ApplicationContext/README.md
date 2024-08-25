
# Pavas.Runtime.ApplicationContext

Pavas.Runtime.ApplicationContext is a library that provides application context management functionalities. It is designed to help developers manage and retrieve the state and configuration of an application environment, making it easier to develop, debug, and deploy applications.

## Features

- **Application State Management**: Provides functionalities to manage and retrieve the state of the application.
- **Environment Configuration**: Facilitates managing different environments (development, production, etc.).
- **Build Mode Management**: Allows handling different build configurations (Debug, Release, etc.).

## Installation

To install the package, you can add it to your project by referencing the `Pavas.Runtime.ApplicationContext` project or by using the NuGet package if available.

## Usage

### Application State Management

You can use the `ApplicationContext` class to retrieve and manage the current state of the application.

```csharp
var applicationContext = new ApplicationContext();
Console.WriteLine(applicationContext.State);
```

### Environment Configuration

The `ApplicationEnvironment` class allows you to manage environment-specific configurations:

```csharp
var environment = ApplicationEnvironment.Current;
Console.WriteLine(environment);
```

### Build Mode Management

Use the `ApplicationBuildMode` class to retrieve and set the build mode of your application:

```csharp
var buildMode = ApplicationBuildMode.Current;
Console.WriteLine(buildMode);
```

## Contributing

If you want to contribute to the project, please fork the repository and submit a pull request. All contributions are welcome!

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
