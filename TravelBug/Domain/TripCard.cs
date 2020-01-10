using System;

namespace Domain
{
  public class TripCard
  {
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
  }
}
