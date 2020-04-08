using Burgler.BusinessLogic.UserLogic;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Burgler.UnitTests
{
    public class BaseApiTests
    {
        public BaseApiTests()
        {
            Login().Wait();

            var userData = DeserializeString<UserData>(LoginContent);

            ClientWithToken = new HttpClient();
            ClientWithToken.BaseAddress = new Uri(ApiUrl);
            ClientWithToken.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userData.Token);
        }
        protected string ApiUrl { get; set; } = "http://localhost:5000/api";
        protected HttpClient Client { get; set; } = new HttpClient();
        protected HttpClient ClientWithToken { get; set; }
        protected HttpResponseMessage LoginResponse { get; set; }
        protected string LoginContent { get; set; }

        // Helper functions
        public T DeserializeString<T>(string givenObject)
        {
            return JsonSerializer.Deserialize<T>(givenObject, options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public StringContent SerializeToJson(object obj)
        {
            return new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");
        }
        public async Task Login(string name = "sam", string password = "Pa$$w0rd")
        {
            var loginObject = new { email = $"{name}@test.com", password };
            var loginContent = SerializeToJson(loginObject);
            LoginResponse = await Client.PostAsync($"{ApiUrl}/user/login", loginContent);
            LoginContent = await LoginResponse.Content.ReadAsStringAsync();
        }

    }
}
