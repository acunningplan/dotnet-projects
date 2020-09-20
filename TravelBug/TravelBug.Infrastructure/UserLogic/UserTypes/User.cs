using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using TravelBug.Entities.UserData;

namespace TravelBug.Infrastructure
{
  public class User
  {
    public User(AppUser user)
    {
        mapAppUsertoUser(user);
    }
    public User(AppUser user, IJwtGenerator jwtGenerator, string refreshToken)
    {
      Token = jwtGenerator.CreateToken(user);
      RefreshToken = refreshToken;
      mapAppUsertoUser(user);
    }

    private void mapAppUsertoUser(AppUser user)
    {
        DisplayName = user.DisplayName;
        Username = user.UserName;
        Bio = user.Bio;
        Photo = user.Photo;
        Followings = user.Followings.Select(f => f.Target.UserName).ToList();
        Followers = user.Followers.Select(f => f.Observer.UserName).ToList();
    }


    public string DisplayName { get; set; }
    public string Bio { get; set; }
    public virtual UserPhoto Photo { get; set; }
    public string Token { get; set; }
    public string Username { get; set; }
    public List<string> Followings { get; set; }
    public List<string> Followers { get; set; }

    [JsonIgnore]
    public string RefreshToken { get; set; }
  }
}