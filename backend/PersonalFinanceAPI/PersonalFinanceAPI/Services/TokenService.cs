
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PersonalFinanceAPI.Models;

namespace PersonalFinanceAPI.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            // Claims = data we store INSIDE the token
            // Anyone who has the token can read these (but not fake them)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name)
            };

            // The secret key used to sign the token
            // If someone changes even one character of the token, this signature breaks
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(
                    double.Parse(_configuration["JwtSettings:ExpiryDays"]!)),
                signingCredentials: credentials
            );

            // Converts the token object to the string format: xxxxx.yyyyy.zzzzz
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}