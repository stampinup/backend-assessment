using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stampin.Api.Common
{
  public class Tree : Plant
  {
    public bool Deciduous { get; set; }
    public bool Conifer { get; set; }
    public Color  FallColor { get; set; }
    public bool SpringFlowers { get; set; }
  }
}
