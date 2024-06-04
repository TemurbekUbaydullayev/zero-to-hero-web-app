using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ZeroToHero.Application.Interfaces;
using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Application.Services;

#pragma warning disable

public class AuthManager(IConfiguration config) : IAuthManager
{
    private readonly IConfiguration _config = config.GetSection("Jwt");


    public async Task<string> LoginEmployeAsync(Employee employee)
    {
        var claims = new[]
        {
            new Claim("Id",employee.Id.ToString()),
            new Claim(ClaimTypes.Name,employee.FirstName+" "+employee.LastName),
            new Claim(ClaimTypes.Email,employee.Email),
            new Claim(ClaimTypes.Role,employee.Role.ToString())
        };

        return GeneratedToken(claims);
    }

    public async Task<string> LoginStudentAsync(Student student)
    {
        var claims = new[]
        {
            new Claim("Id",student.Id.ToString()),
            new Claim(ClaimTypes.Name,student.FirstName+" "+student.LastName),
            new Claim(ClaimTypes.Email,student.Email),
        };

        return GeneratedToken(claims);
    }
    private string GeneratedToken(Claim[] claims)
    {
        var issuer = _config["Issuer"];
        var audience = _config["Audience"];
        var secretKey = _config["SecretKey"];
        var lifeTime = double.Parse(_config["LifeTime"]!);

        var securityKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(issuer, audience, claims,
            expires: DateTime.Now.AddMinutes(lifeTime),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

    }
}
