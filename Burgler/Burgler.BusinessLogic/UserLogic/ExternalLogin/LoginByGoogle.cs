﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.UserLogic
{
    public class GoogleResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string given_name { get; set; }
    }

    public class LoginByGoogle
    {
        public static async Task<GoogleResponse> LoginByGoogleMethod(string accessToken)
        {
            var httpClient = new HttpClient() { BaseAddress = new Uri("https://www.googleapis.com/oauth2/v2/") };
            var response = await httpClient.GetAsync($"userinfo?access_token={accessToken}");
            return JsonSerializer.Deserialize<GoogleResponse>(await response.Content.ReadAsStringAsync());
        }
    }
}
