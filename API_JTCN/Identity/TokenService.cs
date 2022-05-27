using DataTransferObjects;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_JTCN.Identity
{
    public sealed class TokenService : ITokenService
    {
        private readonly string _issuer, _audience, _secret;

        public TokenService(IConfiguration config)
        {
            _issuer = config.GetSection("JwtSettings").GetSection("issuer").Value;
            _audience = config.GetSection("JwtSettings").GetSection("audience").Value;
            _secret = config.GetSection("JwtSettings").GetSection("secret").Value;
        }

        public string GenerateToken(int id, string role)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            //Infos utilisateur
            Claim[] myClaims = new[]
            {
                new Claim(ClaimTypes.Sid, id.ToString()),
                new Claim(ClaimTypes.Role, role),
            };

            JwtSecurityToken token = new JwtSecurityToken
            (
                claims: myClaims,
                signingCredentials: credentials,
                issuer: _issuer,
                audience: _audience,
                expires: DateTime.Now.AddDays(30)
            );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }
    }
}
