using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stampin.Api.Common;

namespace Stampin.Api.DataAccess
{
  public interface IPlantContext
  {

    public Success UpsertTree(Tree request);


    public Success UpsertWeed(Weed request);

    public Success DeleteWeed(string id);

    public Success DeleteTree(string id);

    public Tree GetTreesById(string id);
    public List<Tree> GetTreesByName(string name);
    public List<Tree> GetTreesWithFallColor();
    public List<Tree> GetTreesWithSpringFlowers();
    public List<Tree> GetConiferisTrees();
    public List<Tree> GetDeciduousTrees();


    public Weed GetweedById(string id);
    public List<Weed> GetWeedsByName(string name);
    public List<Weed> GetWeedsWithFlowerColor();
    public List<Weed> GetWeedsWithThorns();
  }
}