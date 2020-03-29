using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace UserEntitiesLib
{
    public class User : IdentityUser
    {
        //public User()
        //{
        //    Photos = new Collection<Photo>();
        //}
        //public virtual ICollection<UserTripCard> UserTripCards { get; set; }
        //public virtual ICollection<Photo> Photos { get; set; }
        public string DisplayName { get; set; }
        public string Bio { get; set; }
    }
}
