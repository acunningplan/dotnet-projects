using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TravelBug.Entities.User
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public virtual UserPhoto UserPhoto { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();
    }
}
