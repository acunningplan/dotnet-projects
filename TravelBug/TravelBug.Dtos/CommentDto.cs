using System;
using System.Collections.Generic;
using TravelBug.Entities;

namespace TravelBug.Dtos
{
  public class CommentDto : Base
  {
    public string Description { get; set; }
    public virtual User Author { get; set; }
    public Guid BlogId { get; set; }
  }
}