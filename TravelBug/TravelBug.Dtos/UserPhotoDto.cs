using TravelBug.Entities;

namespace TravelBug.Dtos
{
  public class UserPhotoDto : Base
  {
    public string ImgurId { get; set; }
    public string Url { get; set; }
    public string Username { get; set; }
  }
}