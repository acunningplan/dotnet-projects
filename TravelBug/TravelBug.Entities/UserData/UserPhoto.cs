namespace TravelBug.Entities.UserData
{
  public class UserPhoto : Base
  {
    public string ImgurId { get; set; } = "";
    public string DeleteHash { get; set; } = "";
    public string Url { get; set; } = "";
    public virtual AppUser User { get; set; }
    public string AppUserId { get; set; } = "";
  }
}
