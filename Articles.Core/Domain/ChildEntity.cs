using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Core.Domain
{
  public abstract class ChildEntity<TKey>
  {
    public TKey Id { get; init; }
  }
}
