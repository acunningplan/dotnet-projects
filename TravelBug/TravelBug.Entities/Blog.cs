using System;
using System.Collections.Generic;
using TravelBug.Entities;
using TravelBug.Entities.User;

namespace TravelBug.Entities
{
    public class Blog : Base
    {
        //public Guid BlogId { get; set; }
        public string Description { get; set; }
        //public Guid UserId { get; set; }
        public virtual AppUser User { get; set; }
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
