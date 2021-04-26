using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Stampin.Api.Common;

namespace Stampin.Api.Business
{
  public class TreeManager : ITreeManager
  {
    public CreateTreesResponse CreateTrees(CreateTreesRequest request)
    {
      throw new NotImplementedException();
    }

    public DeleteTreesResponse DeleteTrees(DeleteTreeRequest request)
    {
      throw new NotImplementedException();
    }

    public GetTreesResponse GetTrees(string value)
    {
      GetTreesRequest request = JsonConvert.DeserializeObject<GetTreesRequest>(value);
      throw new NotImplementedException();
    }

    public UpdateTreesResponse UpdateTrees(UpdateTreesRequest request)
    {
      throw new NotImplementedException();
    }
  }
}
