using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stampin.Api.Common;

namespace Stampin.Api.Business
{
  public interface IWeedManager
  {
    public GetWeedsResponse GetWeeds(GetWeedsRequest request);
    public UpdateWeedsResponse UpdateWeeds(UpdateWeedsRequest request);
    public CreateWeedsResponse CreateWeeds(CreateWeedsRequest request);
    public DeleteWeedsResponse DeleteWeeds(DeleteWeedsRequest request);
  }
}
