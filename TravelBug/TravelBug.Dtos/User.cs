using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TravelBug.Dtos
{
  public class User
  {
    //public User(AppUser user, IMapper mapper)
    //{
    //    mapAppUsertoUser(user, mapper);
    //}
    //public User(AppUser user, IJwtGenerator jwtGenerator, string refreshToken, IMapper mapper)
    //{
    //    Token = jwtGenerator.CreateToken(user);
    //    RefreshToken = refreshToken;
    //    mapAppUsertoUser(user, mapper);
    //}

    //private void mapAppUsertoUser(AppUser user, IMapper mapper)
    //{
    //    DisplayName = user.DisplayName;
    //    Username = user.UserName;
    //    Bio = user.Bio;
    //    Photo = user.Photo;
    //    Blogs = mapper.Map<List<Blog>, List<BlogDto>>(user.Blogs.ToList());
    //    Followings = user.Followings.Select(f => f.Target.UserName).ToList();
    //    Followers = user.Followers.Select(f => f.Observer.UserName).ToList();
    //}


    public string DisplayName { get; set; }
    public string Bio { get; set; }
    public DateTimeOffset LastLogin { get; set; }
    public virtual UserPhotoDto ProfilePicture { get; set; }
    public string Username { get; set; }
    public ICollection<BlogDto> Blogs { get; set; }
    public ICollection<FollowingDto> Followings { get; set; }
    public ICollection<FollowingDto> Followers { get; set; }

    public string Token { get; set; }
    [JsonIgnore]
    public string RefreshToken { get; set; }
  }
}
