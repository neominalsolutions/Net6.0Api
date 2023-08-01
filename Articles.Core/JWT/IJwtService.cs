using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Core.JWT
{
  public interface IJwtService
  {
    TokenReponse GetAccessToken(ClaimsIdentity claimsIdentity, string secretKey, int expireMinutes);
  }
}
