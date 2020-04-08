using System.Net;
using System.Net.Http;
using Xunit;

namespace Burgler.UnitTests
{
    // Start app before testing!
    public class UserApiTests : BaseApiTests
    {
        [Fact]
        public async void ShouldReturnUnauthorizedWithoutLogin()
        {
            try
            {
                HttpResponseMessage response = await Client.PostAsync($"{ApiUrl}/order", new StringContent("No token attached"));
                Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            }
            catch (HttpRequestException e)
            {
                Assert.True(false, e.ToString());
            }
        }

        [Fact]
        public async void ShouldLoginSuccessfully()
        {
            await Login("sarah");
            Assert.True(LoginResponse.IsSuccessStatusCode);
            Assert.NotNull(LoginResponse.Content);
        }

        [Fact]
        public async void ShouldFailToLoginDueToIncorrectUsername()
        {
            await Login("non-existent-username");
            Assert.Equal(HttpStatusCode.Unauthorized, LoginResponse.StatusCode);
        }

        [Fact]
        public async void ShouldFailToLoginDueToIncorrectPassword()
        {
            await Login(password: "bad-password");
            Assert.Equal(HttpStatusCode.Unauthorized, LoginResponse.StatusCode);
        }
    }
}
