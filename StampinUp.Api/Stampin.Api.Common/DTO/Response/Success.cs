using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stampin.Api.Common
{
  public class Success
  {
    public bool Successfull { get; set; }
    public string Msg { get; set; }
    public Exception Ex { get; set; }
  }
}
