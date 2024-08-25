namespace Pavas.Runtime.TenantContext.Contracts;

public interface ITenant
{
    public string Id { get; init; }
    public string Name { get; init; }
    public string Connection { get; init; }
    public bool IsDefault { get; set; }
}