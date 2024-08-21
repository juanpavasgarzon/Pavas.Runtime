using System.Security.Claims;

namespace Pavas.Runtime.IdentityContext;

public sealed class IdentityContext
{
    public string Identifier { get; set; } = string.Empty;
    public string Username { get; set; } = "Anonymous";
    public string Email { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string AuthenticationType { get; set; } = string.Empty;
    public bool IsAuthenticated { get; set; }
    public string IpAddress { get; set; } = string.Empty;
    public List<string> Roles { get; set; } = [];
    public List<Claim> Claims { get; set; } = [];
}