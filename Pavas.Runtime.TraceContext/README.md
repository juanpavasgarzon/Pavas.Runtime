# Pavas.Runtime.TraceContext

**Pavas.Runtime.TraceContext** is a library designed to manage traceability within an application. This library allows
you to easily track the flow of requests and operations, making it easier to diagnose issues and monitor application
behavior.

## Features

- **Traceability**: Provides a middleware and context that enable tracking of requests throughout the application's
  lifecycle.
- **Correlation ID Support**: The library supports the use of `X-Correlation-ID` headers, allowing you to trace requests
  across multiple services.
- **Easy Integration**: Integrates seamlessly with ASP.NET Core via dependency injection and middleware.

## Installation

To use this library, it must be included in the project. This is typically done through dependency injection and
middleware configuration.

## Usage

### Configuring the Trace Context

1. Add the TraceContext to your services during the configuration of the application's services:

    ```csharp
    builder.Services.AddTraceContext();
    ```

2. Use the TraceContext middleware to enable tracing in your application:

    ```csharp
    app.UseTraceContextMiddleware();
    ```

## Contribution

This is a project under continuous development. If you wish to contribute, please fork the repository, create a new
branch, and submit a pull request.

## License

This project is licensed under the terms of the MIT License.
