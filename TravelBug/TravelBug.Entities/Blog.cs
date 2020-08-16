using System;
using System.Collections.Generic;

namespace TravelBug.Entities
{
    public class Blog
    {
        public string Description { get; set; }
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
