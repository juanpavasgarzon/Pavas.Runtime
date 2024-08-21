namespace Pavas.Runtime.TenantContext;

public record Tenant
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Connection { get; set; } = string.Empty;
};