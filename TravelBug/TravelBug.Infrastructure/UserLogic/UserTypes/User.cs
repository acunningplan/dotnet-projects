using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using TravelBug.CrudServices;
using TravelBug.Entities;
using TravelBug.Entities.UserData;

namespace TravelBug.Infrastructure
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
        public virtual UserPhoto Photo { get; set; }
        public string Username { get; set; }
        public ICollection<BlogDto> Blogs { get; set; }
        public List<string> Followings { get; set; } = new List<string>();
        public List<string> Followers { get; set; } = new List<string>();

        public string Token { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; }
    }
}