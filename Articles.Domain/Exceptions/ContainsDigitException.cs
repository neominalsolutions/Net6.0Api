using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Domain.Exceptions
{
  public class ContainsDigitException:Exception
  {
    public ContainsDigitException(string message="numeric değer içeremez"):base(message)
    {

    }
  }
}
