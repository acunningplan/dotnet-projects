using System.Collections.Generic;

namespace Domain
{
  public class PointOfInterest
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Photo> Photo { get; set; }
  }
}