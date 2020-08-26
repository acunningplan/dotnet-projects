using System;
using System.Collections.Generic;
using System.Text;
using TravelBug.Entities.UserData;

namespace TravelBug.Entities
{
    public class BlogDto : Base
    {
        public string Description { get; set; }
        public virtual UserDto User { get; set; }
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
