using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MemberOutReachSystem.Business
{
    public class TokenBuilder : ITokenBuilder
    {
        private readonly string Key;

        

        public TokenBuilder(string key)
        {
            this.Key = key;
        }

        public string  Authenticate (string UserName, string Password)
        {

            string token = BuildToken(UserName);

            return token;
        }
            
        public string BuildToken(string userName)
        {
            var tokenHander = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.ASCII.GetBytes(Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,userName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var Token = tokenHander.CreateToken(tokenDescriptor);

            return tokenHander.WriteToken(Token);
        }

    }
}
