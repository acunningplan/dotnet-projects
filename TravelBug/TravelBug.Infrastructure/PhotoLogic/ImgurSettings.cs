using System;
using System.Collections.Generic;
using System.Text;

namespace TravelBug.Infrastructure.PhotoLogic
{
    public class ImgurSettings
    {
        public string Url { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
        public string Username { get; set; }
    }
}
