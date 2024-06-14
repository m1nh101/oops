using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Oops.Services.Identity.Core.Entities;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Oops.Services.Identity.Application.Utils;

public class JwtTokenGenerator
{
  private readonly IConfiguration _configuration;

  public JwtTokenGenerator(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  public string Generate(User user)
  {
    var secretKey = _configuration["JWT_SECRET_KEY"] ?? throw new NullReferenceException("JWT_SECRET_KEY");
    int.TryParse(_configuration["JWT_EXPIRED_TIME"], out int expiredTime);

    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.UTF8.GetBytes(secretKey);
    var roleClaims = user.GetUserRoles()
      .Select(e => new Claim(ClaimTypes.Role, e));

    var claims = new List<Claim>()
    {
      new(ClaimTypes.NameIdentifier, user.Id.ToString()),
      new(ClaimTypes.Name, user.Username),
    }.Union(roleClaims);

    var tokenDescription = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(claims),
      Expires = DateTime.UtcNow.AddSeconds(expiredTime),
      SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
    };

    var token = tokenHandler.CreateToken(tokenDescription);

    return tokenHandler.WriteToken(token);
  }
}