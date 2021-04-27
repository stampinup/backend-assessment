using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Stampin.Api.Common;
using Stampin.Api.DataAccess;

namespace Stampin.Api.Business
{
  public class WeedManager : IWeedManager
  {
    /// <summary>
    /// the Logger
    /// </summary>
    private readonly ILogger<WeedManager> Logger;

    /// <summary>
    /// the weed manager
    /// </summary>
    private readonly IPlantContext PlantContext;

    public WeedManager(ILogger<WeedManager> logger, IPlantContext plantContext)
    {
      this.Logger = logger;
      this.PlantContext = plantContext;
    }

    /// <inheritdoc />
    public CreateWeedsResponse CreateWeeds(CreateWeedsRequest request)
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc />
    public DeleteWeedsResponse DeleteWeeds(DeleteWeedsRequest request)
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc />
    public GetWeedsResponse GetWeeds(string value)
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc />
    public UpdateWeedsResponse UpdateWeeds(UpdateWeedsRequest request)
    {
      throw new NotImplementedException();
    }
  }
}
