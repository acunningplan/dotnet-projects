namespace TravelBug.Dtos
{
  public class FollowingDto
  {
    public string ObserverId { get; set; }
    public string TargetId { get; set; }
    public User Observer { get; set; }
    public User Target { get; set; }
  }
}