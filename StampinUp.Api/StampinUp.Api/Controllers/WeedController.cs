using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stampin.Api.Business;
using Stampin.Api.Common;

namespace StampinUp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class WeedController : Controller
  {
    private readonly ILogger<WeedController> Logger;
    private readonly IWeedManager WeedManager;

    public WeedController(ILogger<WeedController> logger, IWeedManager weedManager)
    {
      this.Logger = logger;
      this.WeedManager = weedManager;
    }

    [HttpGet("GetWeeds")]
    public ActionResult<GetWeedsResponse> GetWeeds(GetWeedsRequest request)
    {
      try
      {
        GetWeedsResponse response = this.WeedManager.GetWeeds(request);
        if (response != null)
        {
          return response;
        }

        return NotFound("No records exist.");

      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to Get Weeds exception: {@Exception}");
        return BadRequest("There was an error while retrieving records.");
      }
    }


    [HttpPost("CreateWeeds")]
    public ActionResult<CreateWeedsResponse> CreateWeeds(CreateWeedsRequest request)
    {
      try
      {
        CreateWeedsResponse response = this.WeedManager.CreateWeeds(request);
        return response;

      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to create weeds exception: {@Exception}");
        return BadRequest("There was an error while creating records.");
      }
    }

    [HttpPut("UpdateWeeds")]
    public ActionResult<UpdateWeedsResponse> UpdateWeeds(UpdateWeedsRequest request)
    {
      try
      {
        UpdateWeedsResponse response = this.WeedManager.UpdateWeeds(request);
        return response;

      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to update weeds exception: {@Exception}");
        return BadRequest("There was an error while updating records.");
      }
    }

    [HttpDelete("DeleteWeeds")]
    public ActionResult<DeleteWeedsResponse> DeleteWeeds(DeleteWeedsRequest request)
    {
      try
      {
        DeleteWeedsResponse response = this.WeedManager.DeleteWeeds(request);
        return response;


      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to delete weeds exception: {@Exception}");
        return BadRequest("There was an error while deleting records.");
      }
    }
  }
}