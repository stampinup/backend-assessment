using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stampin.Api.Common;

namespace Stampin.Api.Business
{
  public interface ITreeManager
  {
    public GetTreesResponse GetTrees(string value);
    public UpdateTreesResponse UpdateTrees(UpdateTreesRequest request);
    public CreateTreesResponse CreateTrees(CreateTreesRequest request);
    public DeleteTreesResponse DeleteTrees(DeleteTreeRequest request);
  }
}
