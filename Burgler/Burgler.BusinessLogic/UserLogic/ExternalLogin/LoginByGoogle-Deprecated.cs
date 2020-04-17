using Burgler.BusinessLogic.ErrorHandlingLogic;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.UserLogic
{
    public class Web
    {
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string code { get; set; }
        public string grant_type { get; set; } = "authorization_code";
        public string redirect_uri { get; set; } = "http://localhost:5000/oauth2callback";
    }
    internal class GoogleAuthInfo
    {
        public Web web { get; set; }
    }
    public class GoogleAccessTokenInfo
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
    }
    public class GoogleUserInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class LoginByGoogleDeprecated
    {
        public static async Task<GoogleUserInfo> LoginByGoogleMethod(string authorizationCode)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

            // Get client Id and secret from json
            GoogleAuthInfo clientIdAndSecret;
            using (StreamReader r = new StreamReader("google-auth.json"))
            {
                string json = r.ReadToEnd();
                clientIdAndSecret = JsonSerializer.Deserialize<GoogleAuthInfo>(json);
            }

            if (clientIdAndSecret.web.client_id == null)
                throw new RestException(HttpStatusCode.NotFound, "Cannot get client Id");

            //var authInfo = new Web();
            //authInfo.client_id = clientIdAndSecret.web.client_id;
            //authInfo.client_secret = clientIdAndSecret.web.client_secret;
            //authInfo.code = authorizationCode;

            var authContent = new Dictionary<string, string>();
            authContent.Add("client_id", clientIdAndSecret.web.client_id);
            authContent.Add("client_secret", clientIdAndSecret.web.client_secret);
            authContent.Add("code", authorizationCode);
            authContent.Add("grant_type", "authorization_code");
            authContent.Add("redirect_uri", "http://localhost:5000/oauth2callback");

            var attachedContent = new FormUrlEncodedContent(authContent);
            var response = await httpClient.PostAsync("https://oauth2.googleapis.com/token", attachedContent);

            if (!response.IsSuccessStatusCode)
                throw new RestException(response.StatusCode, $"Cannot get access token, \n {await response.Content.ReadAsStringAsync()} ");

            var result = await response.Content.ReadAsStringAsync();
            var accessToken = JsonSerializer.Deserialize<GoogleAccessTokenInfo>(result, options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.access_token);
            response = await httpClient.GetAsync("https://www.googleapis.com/oauth2/v2/userinfo?alt=json");
            result = await response.Content.ReadAsStringAsync();
            var userInfo = JsonSerializer.Deserialize<GoogleUserInfo>(result, options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return userInfo;
        }
    }
}
