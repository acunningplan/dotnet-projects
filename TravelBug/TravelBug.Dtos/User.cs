using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TravelBug.Dtos
{
    public class User
    {
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
