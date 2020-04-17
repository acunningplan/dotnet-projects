using Burgler.BusinessLogic.ErrorHandlingLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.UserLogic
{
    public class FBUserInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    internal class AuthInfo
    {
        public string AppId { get; set; }
        public string AppSecret { get; set; }
    }
    public static class LoginByFB
    {
        public static async Task<FBUserInfo> LoginByFBMethod(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
                throw new RestException(HttpStatusCode.BadRequest, "accessToken is null");

            var _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://graph.facebook.com/");
            _httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Read FB auth info from json file
            AuthInfo authInfo;
            using (StreamReader r = new StreamReader("fb-auth.json"))
            {
                string json = r.ReadToEnd();
                authInfo = JsonSerializer.Deserialize<AuthInfo>(json);
            }



            // Verify token with FB
            var verifyUrl = $"debug_token?input_token={accessToken}&access_token={authInfo.AppId}|{authInfo.AppSecret}";
            var verifyToken = await _httpClient.GetAsync(verifyUrl);


            if (!verifyToken.IsSuccessStatusCode)
                throw new RestException(HttpStatusCode.Unauthorized, "FB token invalid.");

            // Request user info from FB
            var requestUrl = $"me?access_token={accessToken}&fields=name,email";
            var response = await _httpClient.GetAsync(requestUrl);
            if (!verifyToken.IsSuccessStatusCode)
                throw new RestException(HttpStatusCode.NotFound, "Cannot get FB user data.");

            var result = await response.Content.ReadAsStringAsync();
            var userInfo = JsonSerializer.Deserialize<FBUserInfo>(result, options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return userInfo;
        }
    }

}
