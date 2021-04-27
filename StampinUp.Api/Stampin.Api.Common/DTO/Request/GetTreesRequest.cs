namespace Stampin.Api.Common
{
  public class GetTreesRequest
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public bool Deciduous { get; set; }
    public bool Conifer { get; set; }
    public bool FallColor { get; set; }
    public bool SpringFlowers { get; set; }
  }
}
