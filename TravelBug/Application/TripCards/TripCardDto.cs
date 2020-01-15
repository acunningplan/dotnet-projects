using System;
using System.Collections.Generic;
using Domain;

namespace Application.TripCards
{
  public class TripCardDto
  {
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Photo> Photos { get; set; }
    public virtual ICollection<UserTripCard> UserTripCards { get; set; }
  }
}