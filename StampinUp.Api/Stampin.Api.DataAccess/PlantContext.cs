using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Stampin.Api.Common;

namespace Stampin.Api.DataAccess
{
  public class PlantContext : DbContext, IPlantContext
  {
    public PlantContext(ILogger<PlantContext> logger, DbContextOptions<PlantContext> options) : base(options)
    {
    }

    public DbSet<Tree> TreeX { get; set; }
    public DbSet<Weed> WeedX { get; set; }

    public Success UpsertTree(Tree request)
    {
      try
      {
        var item = this.TreeX.FirstOrDefault(x => x.Id == request.Id);
        bool create = item == null;
        item ??= new Tree();
        item.Name = request.Name;
        item.FallColor = request.FallColor;
        item.Conifer = request.Conifer;
        item.Deciduous = request.Deciduous;
        item.SpringFlowers = request.SpringFlowers;
        item.Width = request.Width;
        item.Height = request.Height;
        if (create)
        {
          this.TreeX.Add(item);
        }

        this.SaveChanges();
        return new Success
        {
          Successfull = true
        };
      }
      catch (Exception ex)
      {
        return new Success
        {
          Msg = $"unable to upsert Tree: {JsonConvert.SerializeObject(request)}",
          Successfull = false,
          Ex = ex
        };
      }
    }


    public Success UpsertWeed(Weed request)
    {
      try
      {
        var item = this.WeedX.FirstOrDefault(x => x.Id == request.Id);
        bool create = item == null;
        item ??= new Weed();
        item.Name = request.Name;
        item.FlowerColor = request.FlowerColor;
        item.OverallColor = request.OverallColor;
        item.Thorns = request.Thorns;
        item.Width = request.Width;
        item.Height = request.Height;
        if (create)
        {
          this.WeedX.Add(item);
        }

        this.SaveChanges();
        return new Success
        {
          Successfull = true
        };

      }
      catch (Exception ex)
      {
        return new Success
        {
          Msg = $"unable to upsert Weed: {JsonConvert.SerializeObject(request)}",
          Successfull = false,
          Ex = ex
        };
      }
    }


    public Success DeleteWeed(string id)
    {
      try
      {
        var item = this.WeedX.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
          item = null;
          this.SaveChanges();
        }

        return new Success
        {
          Successfull = true
        };
      }
      catch (Exception ex)
      {
        return new Success
        {
          Msg = $"unable to Delete Weed: {id}",
          Successfull = false,
          Ex = ex
        };
      }
    }

    public Success DeleteTree(string id)
    {
      try
      {
        var item = this.TreeX.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
          item = null;
          this.SaveChanges();
        }

        return new Success
        {
          Successfull = true
        };
      }
      catch (Exception ex)
      {
        return new Success
        {
          Msg = $"unable to Delete Tree: {id}",
          Successfull = false,
          Ex = ex
        };
      }
    }

    public Tree GetTreesById(string id)
    {
      try
      {
        return this.TreeX.FirstOrDefault(x => x.Id == id);
      }
      catch (Exception)
      {
        throw;
        };
    }
    public List<Tree> GetTreesByName(string name)
    {
      try
      {
        return this.TreeX.Where(x => x.Name.Contains(name)).ToList();
      }
      catch (Exception)
      {
        throw;
      };
    }
    public List<Tree> GetTreesWithFallColor()
    {
      try
      {
        return this.TreeX.Where(x => x.FallColor != Color.None).ToList();
      }
      catch (Exception)
      {
        throw;
      };
    }
    public List<Tree> GetTreesWithSpringFlowers()
    {
      try
      {
        return this.TreeX.Where(x => x.SpringFlowers).ToList();
      }
      catch (Exception)
      {
        throw;
      };
    }
    public List<Tree> GetConiferisTrees()
    {
      try
      {
        return this.TreeX.Where(x => x.Conifer).ToList();
      }
      catch (Exception)
      {
        throw;
      };
    }
    public List<Tree> GetDeciduousTrees()
    {
      try
      {
        return this.TreeX.Where(x => x.Deciduous).ToList();
      }
      catch (Exception)
      {
        throw;
      };
    }


    public Weed GetweedById(string id)
    {
      try
      {
        return this.WeedX.FirstOrDefault(x => x.Id == id);
      }
      catch (Exception)
      {
        throw;
      };
    }
    public List<Weed> GetWeedsByName(string name)
    {
      try
      {
        return this.WeedX.Where(x => x.Name.Contains(name)).ToList();
      }
      catch (Exception)
      {
        throw;
      };
    }
    public List<Weed> GetWeedsWithFlowerColor()
    {
      try
      {
        return this.WeedX.Where(x => x.FlowerColor != Color.None).ToList();
      }
      catch (Exception)
      {
        throw;
      };
    }
    public List<Weed> GetWeedsWithThorns()
    {
      try
      {
        return this.WeedX.Where(x => x.Thorns).ToList();
      }
      catch (Exception)
      {
        throw;
      };
    }
  }
}
