using GiftVote.BLL.Authentication;
using GiftVote.BLL.Contracts;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GiftVote.Data.Models;

namespace GiftVote.BLL.Services
{
    public sealed class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;

        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public string Generate(Employee employee)
        {
            var claims = new Claim[]
            {
                new(JwtRegisteredClaimNames.Sub, employee.Id.ToString()),
                new(JwtRegisteredClaimNames.PreferredUsername, employee.UserName.ToString()),
            };

            var signingCredentials = new SigningCredentials(
                                                            new SymmetricSecurityKey(
                                                             Encoding.UTF8.GetBytes(_options.SecretKey)),
                                                            SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                                             _options.Issuer,
                                             _options.Audience,
                                             claims,
                                             null,
                                             DateTime.UtcNow.AddHours(1),
                                             signingCredentials);

            string tokenValue = new JwtSecurityTokenHandler()
                .WriteToken(token);

            return tokenValue;

        }
    }
}
