﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Core.EF
{
  public interface IUnitOfWork
  {
    int Commit();
  }
}
