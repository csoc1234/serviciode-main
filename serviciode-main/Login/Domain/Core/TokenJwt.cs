using Login.Domain.Entity;
using Login.Domain.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TFHKA.Login.Domain.Core
{
    public class TokenJwt : ITokenJwt
    {
        private readonly IConfiguration _configuration;

        public TokenJwt(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenJwtUser GetToken(UserBase enterprise)
        {
            try
            {
                SigningCredentials signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"])), SecurityAlgorithms.HmacSha256);

                int hours = Convert.ToInt16(_configuration["Expiration:TimeHour"]);

                DateTime exp = DateTime.UtcNow.AddHours(hours);

                JwtHeader header = new JwtHeader(signingCredentials);

                JwtPayload payload = new JwtPayload(_configuration["Token:Issuer"], null, new List<Claim>(), null, exp, DateTime.UtcNow);

                Dictionary<string, object> contextUser = new Dictionary<string, object> {
                    { "Id", enterprise.Id },
                    { "Username", enterprise.Username },
                    { "NameApplication", enterprise.NameApplication }
                };

                Dictionary<string, object> context = new Dictionary<string, object> { { "User", contextUser } };

                payload.Add("context", context);

                JwtSecurityToken token = new JwtSecurityToken(header, payload);

                return new TokenJwtUser { Token = new JwtSecurityTokenHandler().WriteToken(token), PasswordExpiration = exp };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
