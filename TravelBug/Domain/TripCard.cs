using System;
using System.Collections.Generic;

namespace Domain
{
  public class TripCard
  {
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<PointOfInterest> PointsOfInterest { get; set; }
    public virtual UserTripCard UserTripCard { get; set; }

  }
}
