using System.Collections.Generic;
using TravelBug.Entities.UserData;

namespace TravelBug.Entities
{
    public class Blog : Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Coordinates { get; set; }
        public string Location { get; set; }
        public virtual AppUser User { get; set; }
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
