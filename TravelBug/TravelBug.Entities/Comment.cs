

using TravelBug.Entities.UserData;

namespace TravelBug.Entities
{
  public class Comment : Base
  {
    public string Description { get; set; }
    public virtual AppUser Author { get; set; }
    public virtual Blog Blog { get; set; }
  }
}