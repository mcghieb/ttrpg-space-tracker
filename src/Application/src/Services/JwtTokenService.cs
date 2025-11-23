using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;

public interface IJwtTokenService
{
    string GenerateToken(Guid userId, string username, string email, bool isAdmin);
}

public class JwtTokenService(JwtSettings jwtSettings) : IJwtTokenService
{
    public string GenerateToken(Guid userId, string username, string email, bool isAdmin)
    {
        var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, userId.ToString()),
            new (ClaimTypes.Name, username),
            new (ClaimTypes.Email, email),
            new ("isAdmin", isAdmin.ToString().ToLower())
        };

        if (isAdmin)
        {
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtSettings.Issuer,
            audience: jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(jwtSettings.ExpirationMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
