using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stampin.Api.Business;
using Stampin.Api.Common;

namespace StampinUp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TreeController : Controller
  {
    private readonly ILogger<TreeController> Logger;
    private readonly ITreeManager TreeManager;

    public TreeController(ILogger<TreeController> logger, ITreeManager treeManager)
    {
      this.Logger = logger;
      this.TreeManager = treeManager;
    }

    [HttpGet("GetTrees{value}")]
    public ActionResult<GetTreesResponse> GetTrees(string value)
    {
      try
      {
        GetTreesResponse response = this.TreeManager.GetTrees(value);
        if (response != null)
        {
          return response;
        }

        return NotFound("No records exist.");

      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to Get Trees exception: {@Exception}");
        return BadRequest("There was an error while retrieving records.");
      }
    }


    [HttpPost("CreateTrees")]
    public ActionResult<CreateTreesResponse> CreateTrees(GetTreesRequest request)
    {
      try
      {
        CreateTreesResponse response = this.TreeManager.CreateTrees(new CreateTreesRequest());
        return response;

      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to create trees exception: {@Exception}");
        return BadRequest("There was an error while creating records.");
      }
    }

    [HttpPut("UpdateTrees")]
    public ActionResult<UpdateTreesResponse> UpdateTrees(UpdateTreesRequest request)
    {
      try
      {
        UpdateTreesResponse response = this.TreeManager.UpdateTrees(request);
        return response;

      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to update trees exception: {@Exception}");
        return BadRequest("There was an error while updating records.");
      }
    }

    [HttpDelete("DeleteTrees")]
    public ActionResult<DeleteTreesResponse> DeleteTrees(DeleteTreeRequest request)
    {
      try
      {
        DeleteTreesResponse response = this.TreeManager.DeleteTrees(request);
        return response;


      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to delete trees exception: {@Exception}");
        return BadRequest("There was an error while deleting records.");
      }
    }
  }
}
