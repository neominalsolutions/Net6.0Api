using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Core.JWT
{
  public class MicrosoftJwtBearerService : IJwtService
  {
    public TokenReponse GetAccessToken(ClaimsIdentity claimsIdentity, string secretKey, int expireMinutes)
    {
      var key = Encoding.ASCII.GetBytes(secretKey);
      var tokenHandler = new JwtSecurityTokenHandler();
      var descriptor = new SecurityTokenDescriptor
      {
        //Issuer = "www.a.com",
        //Audience = "www.b.com",
        Subject = claimsIdentity,
        Expires = DateTime.UtcNow.AddMinutes(expireMinutes),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)
      };
      var token = tokenHandler.CreateToken(descriptor);
      var accessToken = tokenHandler.WriteToken(token);

      return new TokenReponse
      {
        AccessToken = accessToken
      };

    }
  }
}
