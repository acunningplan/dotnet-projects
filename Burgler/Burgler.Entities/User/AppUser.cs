using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Burgler.Entities.OrderNS;
using Microsoft.AspNetCore.Identity;

namespace Burgler.Entities.User
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Orders = new Collection<Order>();
        }
        //public virtual ICollection<UserTripCard> UserTripCards { get; set; }
        //public virtual ICollection<Photo> Photos { get; set; }
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
