using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Stampin.Api.Common;
using Stampin.Api.DataAccess;

namespace Stampin.Api.Business
{
  /// <inheritdoc />
  public class TreeManager : ITreeManager
  {
    /// <summary>
    /// the Logger
    /// </summary>
    private readonly ILogger<TreeManager> Logger;

    /// <summary>
    /// the weed manager
    /// </summary>
    private readonly IPlantContext PlantContext;

    public TreeManager(ILogger<TreeManager> logger, IPlantContext plantContext)
    {
      this.Logger = logger;
      this.PlantContext = plantContext;
    }

    /// <inheritdoc />
    public CreateTreesResponse CreateTrees(CreateTreesRequest request)
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc />
    public DeleteTreesResponse DeleteTrees(DeleteTreeRequest request)
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc />
    public GetTreesResponse GetTrees(string value)
    {
      GetTreesRequest request = JsonConvert.DeserializeObject<GetTreesRequest>(value);
      throw new NotImplementedException();
    }

    /// <inheritdoc />
    public UpdateTreesResponse UpdateTrees(UpdateTreesRequest request)
    {
      throw new NotImplementedException();
    }
  }
}
