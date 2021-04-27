using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stampin.Api.Common
{
  public class GetWeedsRequest
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public bool Thorns { get; set; }
    public Color FlowerColor { get; set; }
  }
}
