using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Core.Domain
{
  public interface ICreatedEntity
  {
    DateTime CreateAt { get; set; }
    string CreatedBy { get; set; }
  }
}
