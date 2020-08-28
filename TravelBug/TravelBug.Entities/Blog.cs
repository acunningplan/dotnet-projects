using System.Collections.Generic;
using TravelBug.Entities.UserData;

namespace TravelBug.Entities
{
    public class Blog : Base
    {
        public string Description { get; set; }
        public virtual AppUser User { get; set; }
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
