using Microsoft.Extensions.Configuration;
//using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;
using Xunit.Sdk;
using System.Threading.Tasks;

namespace Burgler.UnitTests
{
    // Start app before testing!
    public class UserApiTests
    {
        static readonly HttpClient client = new HttpClient();
        private readonly string _apiUrl = "http://localhost:5000/api";

        [Fact]
        public async void ShouldReturnOk()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{_apiUrl}/order");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
            catch (HttpRequestException e)
            {
                Assert.True(false, e.ToString());
            }

            //Assert.Equal(true, result)
        }
        [Fact]
        public async void ShouldReturnUnauthorized()
        {
            try
            {
                //var stringContent = new FormUrlEncodedContent(new Dictionary<string, string>());
                var content = new StringContent("asdf");
                HttpResponseMessage response = await client.PostAsync($"{_apiUrl}/order", content);
                Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            }
            catch (HttpRequestException e)
            {
                Assert.True(false, e.ToString());
            }
        }

        public async Task<HttpResponseMessage> Login()
        {
            var loginDict = new Dictionary<string, string>();
            loginDict.Add("email", "sam@test.com");
            loginDict.Add("password", "Pa$$w0rd");
            var loginContent = new StringContent(JsonSerializer.Serialize(loginDict), Encoding.UTF8, "application/json");
            return await client.PostAsync("http://localhost:5000/api/user/login", loginContent);
        }

        [Fact]
        public async void ShouldLoginSuccessfully()
        {
            HttpResponseMessage loginResponse = await Login();
            Assert.Equal(HttpStatusCode.OK, loginResponse.StatusCode);
        }
        //[Fact]
        //public async void ShouldReturnBadRequest()
        //{
        //    try
        //    {
        //        var loginDict = new Dictionary<string, string>();
        //        loginDict.Add("email", "sam@test.com");
        //        loginDict.Add("password", "Pa$$w0rd");
        //        var loginContent = new FormUrlEncodedContent(loginDict);
        //        HttpResponseMessage loginResponse = await client.PostAsync("http://localhost:5000/api/user/login", loginContent);
        //        Assert.Equal(HttpStatusCode.OK, loginResponse.StatusCode);

        //        //loginResponse.Content;

        //        HttpContent content = loginResponse.Content;

        //        var header = new HttpRequestHeader();

        //        ////var stringContent = new FormUrlEncodedContent(new Dictionary<string, string>());
        //        //var content = new StringContent("asdf");
        //        HttpResponseMessage response = await client.PostAsync("http://localhost:5000/api/order", loginResponse.Content);
        //        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        Assert.True(false, e.ToString());
        //    }
        //}
    }
}
