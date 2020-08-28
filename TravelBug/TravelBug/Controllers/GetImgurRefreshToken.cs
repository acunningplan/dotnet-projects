using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using TravelBug.Infrastructure.PhotoLogic;

namespace TravelBug.Web.Controllers
{
    public class GetImgurRefreshToken : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ImgurSettings _settings;

        public GetImgurRefreshToken(IOptions<ImgurSettings> config, IHttpClientFactory clientFactory)
        {
            _settings = config.Value;

            // Create http client and set base address and access token
            _httpClient = clientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(_settings.Url);


        }
        //public async Task GetRefreshToken()
        //{
        //    //return View();
        //}
    }
}
