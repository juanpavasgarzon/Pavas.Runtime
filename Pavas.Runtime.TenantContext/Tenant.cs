using Pavas.Runtime.TenantContext.Contracts;

namespace Pavas.Runtime.TenantContext;

public record Tenant : ITenant
{
    public Tenant()
    {
    }

    public Tenant(string id, string name, string connection)
    {
        Id = id;
        Name = name;
        Connection = connection;
    }

    public string Id { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string Connection { get; init; } = string.Empty;
    public bool IsDefault { get; set; }
};