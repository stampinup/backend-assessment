using System;
using System.Collections.Generic;
using System.Linq;
using Stampin.Api.Common;

namespace Stampin.Api.DataAccess
{
  public class InitilizeDb
  {
    public static void Initialize(PlantContext context)
    {
      context.Database.EnsureCreated();

      if (context.TreeX.Any() || context.WeedX.Any())
      {
        return;
      }

      context.TreeX.Add(new Tree
      {
        Id = "TD1",
        Height = "35 ft",
        Width = "20 ft",
        Conifer = true,
        Deciduous = true,
        FallColor = Color.None,
        SpringFlowers = false,
        Name = "Taxodium Distichum (Bald Cypress)"
      });


      context.TreeX.Add(new Tree
      {
        Id = "AR1",
        Height = "30 ft",
        Width = "20 ft",
        Conifer = false,
        Deciduous = true,
        FallColor = Color.Red,
        SpringFlowers = false,
        Name = "Acer Rubrum (Red Maple)"
      });

      context.TreeX.Add(new Tree
      {
        Id = "ZS1",
        Height = "20 ft",
        Width = "10 ft",
        Conifer = false,
        Deciduous = true,
        FallColor = Color.Yellow,
        SpringFlowers = false,
        Name = "Zelkova Serrata (ZelKova)"
      });

      context.SaveChanges();

      context.WeedX.Add(new Weed
      {
        Id = "CV1",
        Height = "2.5 ft",
        Width = "3 in",
        FlowerColor = Color.Purple,
        OverallColor = Color.Green,
        Name = "Cirsium vulgare (Bull Thistle)",
        Thorns = true
      });

      context.WeedX.Add(new Weed
      {
        Id = "MN1",
        Height = "2 in",
        Width = "6 in",
        FlowerColor = Color.Purple,
        OverallColor = Color.Green,
        Name = "Malva Neglecta (Common Mallow)",
        Thorns = true
      });

      context.WeedX.Add(new Weed
      {
        Id = "IP1",
        Height = "Climbs",
        Width = "Spreads",
        OverallColor = Color.Green,
        FlowerColor = Color.White,
        Name = "Ipomoea purpurea (Morning Glory)",
        Thorns = true
      });

      context.WeedX.Add(new Weed
      {
        Id = "T1",
        Height = "6 in",
        Width = "6 in",
        OverallColor = Color.Green,
        FlowerColor = Color.Yellow,
        Name = "Taraxacum (Dandy Lion)",
        Thorns = true
      });

      context.SaveChanges();
    }
  }
}
