using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Core.Domain
{
  public abstract class RootEntity<TKey> : ICreatedEntity
  {
    public TKey Id { get; init; }
    public DateTime CreateAt { get; set; }
    public string CreatedBy { get; set; }
  }
}
