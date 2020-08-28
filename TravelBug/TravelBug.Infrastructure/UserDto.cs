using System.Text.Json.Serialization;
using TravelBug.Entities.UserData;

namespace TravelBug.Infrastructure
{
    public class UserDto
    {
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public virtual UserPhoto Photo { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }
    }
}
