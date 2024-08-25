# Pavas.Runtime.TenantContext

**Pavas.Runtime.TenantContext** is a library designed to manage multi-tenancy in applications, allowing for dynamic
tenant selection based on request headers or default tenant configurations. This is particularly useful in environments
where the same application serves multiple clients (tenants) and needs to differentiate between them based on the
incoming request.

## Features

- **Multi-Tenant Support**: Manage multiple tenants with ease by specifying a list of tenants and selecting the
  appropriate one based on the `X-Tenant-ID` header or a default setting.
- **Dynamic Tenant Resolution**: The tenant can be dynamically resolved from the incoming request header `X-Tenant-ID`.
  If the header is not provided, the system will use the default tenant as defined in the configuration.
- **Centralized Configuration**: The tenants are configured centrally, making it easy to manage and update tenant
  information.

## Installation

To use this library, include it in your project and configure the tenant context as part of your service configuration.

## Usage

### Configuring Tenants

1. Define a list of tenants and set one as the default:

    ```csharp
    List<Tenant> tenants =
    [
        new Tenant
        {
            Id = "Develop",
            Name = "Develop",
            Connection = "MyConnectionDevelop",
            IsDefault = true
        },
        new Tenant
        {
            Id = "ProductionTenant",
            Name = "ProductionTenant",
            Connection = "MyConnectionToProduction"
        },
        new Tenant
        {
            Id = "TestTenant",
            Name = "TestTenant",
            Connection = "MyConnectionToTest"
        }
    ];
    ```

2. Inject the tenant context during the application service configuration:

    ```csharp
    builder.Services.AddTenantContext(tenants);
    ```

3. Use the TenantContext middleware to enable tenants in your application:

    ```csharp
    app.UseTenantContextMiddleware();
    ```

### Handling Tenant Resolution

- **Header-Based Resolution**: The tenant is resolved based on the `X-Tenant-ID` header included in the HTTP request.
  This allows the application to dynamically switch between tenants depending on the incoming request.
- **Default Tenant**: If the `X-Tenant-ID` header is not provided, the application will fall back to the tenant marked
  as `IsDefault` in the tenant configuration list.

## Contribution

This is an ongoing project. If you wish to contribute, please fork the repository, create a new branch, and submit a
pull request.

## License

This project is licensed under the MIT License.
