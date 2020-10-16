using System.Collections.Generic;
using TravelBug.Entities;

namespace TravelBug.Dtos
{
  public class BlogDto : Base
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<ImageDto> Images { get; set; } = new List<ImageDto>();
    public virtual ICollection<CommentDto> Comments { get; set; }

  }
}
