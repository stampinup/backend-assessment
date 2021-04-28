using Moq;
using NUnit.Framework;
using Stampin.Api.Business;
using Stampin.Api.Common;
using Stampin.Api.DataAccess;
using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Stampin.Api.Test
{
  public class Tests
  {
    TreeManager TreeManager;
    private Mock<ILogger<TreeManager>> testLogger;
    private Mock<IPlantContext> PlantC;

   [SetUp]
    public void Setup()
    {
      PlantC = new Mock<IPlantContext>();
      testLogger = new Mock<ILogger<TreeManager>>();
      TreeManager = new TreeManager(testLogger.Object, this.PlantC.Object);
    }

    [Test]
    public void GetTreesById()
    {
      var expected = new Response<Tree> { Successfull = true, Values = new Tree { Conifer = false, Deciduous = true, FallColor = Color.Red, Id = 1, Name = "Acer Rubrum (Red Maple)" } };
      this.PlantC.Setup(x => x.GetTreesById(It.IsAny<int>())).Returns(expected);
      var result = TreeManager.GetTrees("Id=1");
      Assert.IsTrue(expected.Successfull == result.Success.Successfull && expected.Values.Name == result.Trees["Id"][0].Name);
    }

    [Test]
    public void GetTreesByIdZero()
    {
      var expected = new Response<Tree> { Successfull = false, Values = null };
      this.PlantC.Setup(x => x.GetTreesById(It.IsAny<int>())).Returns(expected);
      var result = TreeManager.GetTrees("Id=0");
      Assert.IsTrue(expected.Successfull == result.Success.Successfull &&  result?.Trees.Count == 0);
    }

    [Test]
    public void GetTreesByIdString()
    {
      var expected = new Response<Tree> { Successfull = false, Values = null };
      this.PlantC.Setup(x => x.GetTreesById(It.IsAny<int>())).Returns(expected);
      var result = TreeManager.GetTrees("Id=F");
      Assert.IsTrue(expected.Successfull == result.Success.Successfull && result?.Trees.Count == 0);
    }

    [Test]
    public void GetTreesByIdSpelling()
    {
      var expected = new Response<Tree> { Successfull = false, Values = null };
      this.PlantC.Setup(x => x.GetTreesById(It.IsAny<int>())).Returns(expected);
      var result = TreeManager.GetTrees("Is=1");
      Assert.IsTrue(expected.Successfull == result.Success.Successfull && result?.Trees.Count == 0);
    }

    [Test]
    public void GetTreesByFallColor()
    {
      var expected = new Response<List<Tree>> { Successfull = true, Values = new List<Tree> { new Tree { Conifer = false, Deciduous = true, FallColor = Color.Red, Id = 1, Name = "Acer Rubrum (Red Maple)" }, new Tree { Conifer = false, Deciduous = true, FallColor = Color.Yellow, Id = 5, Name = "Zelkova" } } };
      this.PlantC.Setup(x => x.GetTreesWithFallColor()).Returns(expected);
      var result = TreeManager.GetTrees("FallColor=true");
      Assert.IsTrue(expected.Successfull == result.Success.Successfull && result?.Trees.Count == 1);
      Assert.IsTrue(result?.Trees["FallColor"].Count == 2 && result?.Trees["FallColor"][1].Name == expected.Values[1].Name);
    }

    [Test]
    public void GetTrees()
    {
      var fallTrees = new Response<List<Tree>> { Successfull = true, Values = new List<Tree> { new Tree { Conifer = false, Deciduous = true, FallColor = Color.Red, Id = 1, Name = "Acer Rubrum (Red Maple)" }, new Tree { Conifer = false, Deciduous = true, FallColor = Color.Yellow, Id = 5, Name = "Zelkova" } } };
      var springTrees = new Response<List<Tree>> { Successfull = true, Values = new List<Tree> { new Tree { Conifer = false, Deciduous = true, FallColor = Color.Red, Id = 1, Name = "Pyrus calleryana (Bradford Pair)" }, new Tree { Conifer = false, Deciduous = true, FallColor = Color.Yellow, Id = 5, Name = "Malus (Apple)" } } };
      var treeName = new Response<List<Tree>> { Successfull = true, Values = new List<Tree> { new Tree { Conifer = false, Deciduous = true, FallColor = Color.Yellow, Id = 5, Name = "Malus (Apple)" } } };
      var deciduous = new Response<List<Tree>> { Successfull = true, Values = new List<Tree> { new Tree { Conifer = false, Deciduous = true, FallColor = Color.Red, Id = 1, Name = "Pyrus calleryana (Bradford Pair)" }, new Tree { Conifer = false, Deciduous = true, FallColor = Color.Yellow, Id = 5, Name = "Malus (Apple)" } } };
      var conifers = new Response<List<Tree>> { Successfull = true, Values = new List<Tree> { new Tree { Conifer = true, Deciduous = true, FallColor = Color.Red, Id = 1, Name = "bald cypress" } } };
      var treeId = new Response<Tree> { Successfull = true, Values = new Tree { Conifer = false, Deciduous = true, FallColor = Color.Red, Id = 1, Name = "Acer Rubrum (Red Maple)" } };
      this.PlantC.Setup(x => x.GetTreesWithFallColor()).Returns(fallTrees);
      this.PlantC.Setup(x => x.GetTreesWithSpringFlowers()).Returns(springTrees);
      this.PlantC.Setup(x => x.GetTreesById(1)).Returns(treeId);
      this.PlantC.Setup(x => x.GetTreesById(0)).Returns(treeId);
      this.PlantC.Setup(x => x.GetDeciduousTrees()).Returns(deciduous);
      this.PlantC.Setup(x => x.GetConiferisTrees()).Returns(conifers);
      this.PlantC.Setup(x => x.GetTreesByName("Malus(Apple)")).Returns(treeName);
      var result = TreeManager.GetTrees("Id=1&Name=Acer&Deciduous=false&Conifer=false&FallColor=true&SpringFlowers=true");
      Assert.IsTrue(result.Success.Successfull == false && result?.Trees.Count == 3);
      Assert.IsTrue(result?.Trees["FallColor"].Count == 2 && result?.Trees["FallColor"][1].Name != springTrees.Values[1].Name);
    }
  }
}