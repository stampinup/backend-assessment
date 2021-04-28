using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
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

    public TreeManager(ILogger<TreeManager> logger, IServiceProvider serviceProvider)
    {
      this.Logger = logger;
      this.PlantContext = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<PlantContext>();
    }

    /// <inheritdoc />
    public CreateTreesResponse CreateTrees(CreateTreesRequest request)
    {
      CreateTreesResponse response = new CreateTreesResponse();
      try
      {
        if (request?.Trees != null)
        {
          response.Success = this.PlantContext.UpsertTree(request.Trees);
        }
        else
        {
          response.Success = new Success
          {
            Msg = "unable to create trees",
            Successfull = false
          };
        }

      }
      catch (Exception)
      {
        new UpdateWeedsResponse
        {
          Success = new Success
          {
            Msg = "There was an error creating trees",
            Successfull = false
          }
        };
      }
      return response;
    }

    /// <inheritdoc />
    public DeleteTreesResponse DeleteTrees(DeleteTreeRequest request)
    {
      DeleteTreesResponse response = new DeleteTreesResponse();
      if (request != null)
      {
        response.Success = this.PlantContext.DeleteTree(request.Id);
      }

      return response;
    }

    /// <inheritdoc />
    public GetTreesResponse GetTrees(string value)
    {
      GetTreesResponse treeResponse = new GetTreesResponse { Trees = new Dictionary<string, List<Tree>>(), Success = new Success() };
      try
      {
        bool failed = false;
        string[] pairs = value?.Split('&');
        Dictionary<string, string> arguments = new Dictionary<string, string>();
        foreach (var pair in pairs ?? new string[0])
        {
          var set = pair.Split("=");
          if (set.Count() != 2)
          {
            return new GetTreesResponse
            {
              Success = new Success
              {
                Successfull = false,
                Msg = "Unable to parse input string"
              }
            };
          }

          arguments.Add(set[0], set[1]);
        }

        foreach (var item in arguments)
        {
          switch (item.Key)
          {
            case "Id":
              {
                bool valid = int.TryParse(item.Value, out int result);
                if (valid)
                {
                  var ids = this.PlantContext.GetTreesById(result);
                  if (ids.Successfull && ids.Values != null)
                  {
                    treeResponse.Trees.Add(item.Key, new List<Tree> { ids.Values });
                  }
                  else
                  {
                    failed = true;
                  }
                }
                break;
              }
            case "Name":
              {
                var names = this.PlantContext.GetTreesByName(item.Value);
                if (names.Successfull && names.Values != null)
                {
                  treeResponse.Trees.Add(item.Key, names.Values);
                }
                else
                {
                  failed = true;
                }
                break;
              }
            case "Deciduous":
              {
                var deciduous = this.PlantContext.GetDeciduousTrees();
                if (deciduous.Successfull && deciduous.Values != null)
                {
                  treeResponse.Trees.Add(item.Key, deciduous.Values);
                }
                else
                {
                  failed = true;
                }
                break;
              }
            case "Conifer":
              {
                var conifer = this.PlantContext.GetConiferisTrees();
                if (conifer.Successfull && conifer.Values != null)
                {
                  treeResponse.Trees.Add(item.Key, conifer.Values);
                }
                else
                {
                  failed = true;
                }
                break;
              }
            case "FallColor":
              {
                var fallColor = this.PlantContext.GetTreesWithFallColor();
                if (fallColor.Successfull && fallColor.Values != null)
                {
                  treeResponse.Trees.Add(item.Key, fallColor.Values);
                }
                else
                {
                  failed = true;
                }
                break;
              }
            case "SpringFlowers":
              {
                var springFlowers = this.PlantContext.GetTreesWithSpringFlowers();
                if (springFlowers.Successfull && springFlowers.Values != null)
                {
                  treeResponse.Trees.Add(item.Key, springFlowers.Values);
                }
                else
                {
                  failed = true;
                }
                break;
              }
            default:
              {
                failed = true;
                break;
              }
          }
        }
        treeResponse.Success.Successfull = !failed;
        return treeResponse;
      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unsuccessfull in getting trees");
        treeResponse.Success.Msg = "Unsuccessfull in getting trees";
        return treeResponse;
      }
    }

    /// <inheritdoc />
    public UpdateTreesResponse UpdateTrees(UpdateTreesRequest request)
    {
      UpdateTreesResponse response = new UpdateTreesResponse();
      try
      {
        if (request?.Trees != null)
        {
          response.Success = this.PlantContext.UpsertTree(request.Trees);
        }
        else
        {
          response.Success = new Success
          {
            Msg = "unable to update trees",
            Successfull = false
          };
        }

      }
      catch (Exception)
      {
        new UpdateWeedsResponse
        {
          Success = new Success
          {
            Msg = "There was an error updating trees",
            Successfull = false
          }
        };
      }
      return response;
    }
  }
}
