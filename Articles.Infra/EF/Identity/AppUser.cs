﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Infra.EF.Identity
{
  public class AppUser:IdentityUser<string>
  {
  }
}
