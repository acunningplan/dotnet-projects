using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Domain;
using Application.User;

namespace Application.TripCards
{
  public class TripCardDto
  {
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<PointOfInterest> PointsOfInterest { get; set; }
    
    [JsonPropertyName("author")]
    public virtual AuthorDto UserTripCard { get; set; }
  }
}