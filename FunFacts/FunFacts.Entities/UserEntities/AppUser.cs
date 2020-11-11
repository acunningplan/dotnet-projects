using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunFacts.Entities.UserEntities
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}
