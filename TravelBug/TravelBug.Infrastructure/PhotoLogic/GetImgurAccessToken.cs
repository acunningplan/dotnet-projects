using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelBug.Infrastructure.PhotoLogic
{
    public class GetImgurAccessToken
    {
        private readonly IOptions<ImgurSettings> _config;

        public GetImgurAccessToken(IOptions<ImgurSettings> config)
        {
            _config = config;
        }
    }
}
