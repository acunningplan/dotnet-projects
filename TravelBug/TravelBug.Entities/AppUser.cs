using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TravelBug.Entities.User
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Blogs = new List<Blog>();
        }
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
