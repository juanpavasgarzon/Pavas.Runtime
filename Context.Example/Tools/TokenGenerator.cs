using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Pavas.Runtime.IdentityContext;

namespace Context.Example.Tools;

public class TokenGenerator
{
    public required IdentityContext IdentityContext { get; init; }
    public required string SecretKey { get; init; }
    public string SecurityAlgorithm { get; init; } = SecurityAlgorithms.HmacSha256Signature;
    public DateTime Expires { get; init; } = DateTime.UtcNow.AddDays(1);
    public int Size { get; init; } = 32;
    public required string Issuer { get; set; }

    public string GenerateJwtToken()
    {
        var key = SHA256.HashData(Encoding.UTF8.GetBytes(SecretKey));
        var securityKey = new SymmetricSecurityKey(key);
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithm);
        var iat = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = Issuer,
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, IdentityContext.Identifier),
                new Claim(JwtRegisteredClaimNames.Name, IdentityContext.Username),
                new Claim(JwtRegisteredClaimNames.Email, IdentityContext.Email),
                new Claim(JwtRegisteredClaimNames.Iat, iat, ClaimValueTypes.Integer64),
                new Claim("country", IdentityContext.Country),
                new Claim("gender", IdentityContext.Gender),
                new Claim("postalcode", IdentityContext.PostalCode),
            }),
            Expires = Expires,
            SigningCredentials = signingCredentials
        };

        foreach (var role in IdentityContext.Roles)
        {
            tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role));
        }

        foreach (var claim in IdentityContext.Claims)
        {
            tokenDescriptor.Subject.AddClaim(claim);
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}