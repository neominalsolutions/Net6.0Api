using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Core.JWT
{
  public class TokenReponse
  {
    public string? AccessToken { get; set; }
    public string Type { get; set; } = "JWT";

  }
}
