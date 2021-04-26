using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stampin.Api.Common
{
  public class GetTreesRequest
  {
    public Tree Qualities { get; set; }
    public bool UseId { get; set; }
    public bool UseName { get; set; }
    public bool UseAveSize { get; set; }
    public bool UseDeciduous { get; set; }
    public bool UseConifer { get; set; }
    public bool UseFallColor { get; set; }
    public bool UseSpringFlowers { get; set; }
  }
}
