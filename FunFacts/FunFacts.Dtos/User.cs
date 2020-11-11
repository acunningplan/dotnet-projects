using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FunFacts.Dtos
{
    public class User
    {
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public DateTimeOffset LastLogin { get; set; }
        public string Username { get; set; }

        public string Token { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; }
    }
}
