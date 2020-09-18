using System.Text.Json.Serialization;
using TravelBug.Entities.UserData;

namespace TravelBug.Infrastructure
{
  public class User
  {
    public User(AppUser user)
    {
      DisplayName = user.DisplayName;
      Username = user.UserName;
      Bio = user.Bio;
      Photo = user.Photo;
    }
    public User(AppUser user, IJwtGenerator jwtGenerator, string refreshToken)
    {
      DisplayName = user.DisplayName;
      Token = jwtGenerator.CreateToken(user);
      Username = user.UserName;
      Bio = user.Bio;
      Photo = user.Photo;
      RefreshToken = refreshToken;
    }

    public string DisplayName { get; set; }
    public string Bio { get; set; }
    public virtual UserPhoto Photo { get; set; }
    public string Token { get; set; }
    public string Username { get; set; }

    [JsonIgnore]
    public string RefreshToken { get; set; }
  }
}