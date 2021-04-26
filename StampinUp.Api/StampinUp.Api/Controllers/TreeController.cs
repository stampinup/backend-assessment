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

    [HttpGet("GetTrees")]
    public ActionResult<GetTreesResponse> GetTrees(GetTreesRequest request)
    {
      try
      {
        GetTreesResponse response = this.TreeManager.GetTrees(request);
        if (response != null)
        {
          return response;
        }

        return NotFound("No records exist.");

      }
      catch (Exception ex)
      {
        Logger.LogError("Unable to Get Trees exception: {@Exception}", ex);
        return BadRequest("There was an error while retrieving records.");
      }
    }


    [HttpPost("CreateTrees")]
    public ActionResult<CreateTreesResponse> CreateTrees(CreateTreesRequest request)
    {
      try
      {
        CreateTreesResponse response = this.TreeManager.CreateTrees(request);
        return response;

      }
      catch (Exception ex)
      {
        Logger.LogError("Unable to create trees exception: {@Exception}", ex);
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
        Logger.LogError("Unable to update trees exception: {@Exception}", ex);
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
        Logger.LogError("Unable to delete trees exception: {@Exception}", ex);
        return BadRequest("There was an error while deleting records.");
      }
    }
  }
}
