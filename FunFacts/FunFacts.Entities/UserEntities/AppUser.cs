using FunFacts.Entities.Images;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunFacts.Entities.User
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public DateTimeOffset LastLogin { get; set; }
        public virtual UserPhoto ProfilePicture { get; set; }
        public virtual ICollection<FunFact> FunFacts { get; set; } = new List<FunFact>();
        public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}
