using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Stampin.Api.Common
{
  public class Plant
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Height { get; set; }
    public string Width { get; set; }
  }
}
