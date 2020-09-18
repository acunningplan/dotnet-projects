using System.Collections.Generic;
using TravelBug.Entities;
using TravelBug.Infrastructure;

namespace TravelBug.CrudServices
{
    public class BlogDto : Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual UserDto User { get; set; }
        public virtual ICollection<ImageDto> Images { get; set; } = new List<ImageDto>();
    }
}
