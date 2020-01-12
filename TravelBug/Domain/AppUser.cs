using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
  public class AppUser : IdentityUser
  {
    public AppUser()
    {
      Photos = new Collection<Photo>();
    }
    public string DisplayName { get; set; }
    public ICollection<UserTripCard> UserTripCards { get; set; }
    public virtual ICollection<Photo> Photos { get; set; }
  }
}