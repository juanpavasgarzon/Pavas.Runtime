namespace Pavas.Runtime.TenantContext;

public sealed class TenantContext
{
    public string TenantId { get; set; } = string.Empty;
    public string TenantName { get; set; } = string.Empty;
    public string Connection { get; set; } = string.Empty;
}