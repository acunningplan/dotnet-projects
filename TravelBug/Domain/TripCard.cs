using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Domain
{
    public class TripCard
    {
        public TripCard()
        {
            Photos = new Collection<Photo>();
        }

        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<PointOfInterest> PointsOfInterest { get; set; }
        public virtual UserTripCard UserTripCard { get; set; }
    }
}