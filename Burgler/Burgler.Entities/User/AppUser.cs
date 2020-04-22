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
            Orders = new List<Order>();
        }
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public string Staff { get; set; }
    }
}
