# Pavas.Runtime.IdentityContext

**Pavas.Runtime.IdentityContext** is a library designed to manage user identity, including authentication and authorization, within ASP.NET Core applications. It centralizes user-related information such as roles, claims, and other identity data, making it easier to access and manage across the application.

## Features

- **Centralized Identity Management**: Provides an `IdentityContext` class to encapsulate user identity information.
- **Middleware Support**: Easily integrate identity management into the request pipeline using the `IdentityContextMiddleware`.
- **Claims and Roles Handling**: Simplifies the handling of user claims, roles, and other identity attributes.

## Installation

To use this library, include it in your project through dependency injection.

## Usage

### Setting Up the Identity Context

1. Define the identity context when create a jwt token:

    ```csharp
    var identityContext = new IdentityContext
    {
        Identifier = "1234567890",
        Username = "John Doe",
        Email = "john.doe@example.com",
        Country = "US",
        Gender = "Male",
        PostalCode = "12345",
        AuthenticationType = "Custom",
        IsAuthenticated = true,
        IpAddress = "127.0.0.1",
        Roles = ["Admin", "User"],
        Claims = [new Claim("custom-claim-type", "custom-claim-value")]
    };
    ```

2. Inject the context into the service during application setup:

    ```csharp
    builder.Services.AddIdentityContext();
    ```

3. Add the middleware to the request pipeline:

    ```csharp
    app.UseIdentityContextMiddleware();
    ```

## License

This project is licensed under the MIT License.
