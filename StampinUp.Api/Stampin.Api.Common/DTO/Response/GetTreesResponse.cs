using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stampin.Api.Common
{
  public class GetTreesResponse
  {
    public IEnumerable<Tree> Trees { get; set; }
  }
}
