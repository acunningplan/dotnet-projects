using Burgler.BusinessLogic.UserLogic;
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
                Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
            }
            catch (HttpRequestException e)
            {
                Assert.True(false, e.ToString());
            }
        }

        [Fact]
        public async void ShouldLoginSuccessfully()
        {
            await Login("ed");
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

        [Fact]
        public async void ShouldLoginByFB()
        {
            // Access token by test user (valid for 2 months)
            var query = new ExternalLogin.Query();
            query.AccessToken = "EAADUlPswdigBAAPZCydlZCPuulge0pdIYZA0ZAHZBu5nIZB5FZBObVZBiE41ImOozx6X5rMiBKpzKyIZCPZB5Ptm651OE8ZC87yRgHZAuDynV7zwcjvuY3gJtCuhPbXO3zMeqT3HHdVOBPeoC36HfcXxMY8KmsfmSjb1FZAoDlca5dia2M9jWDbW6F0zQvQNgMBgAZAAsj92NhCkE0vwZDZD";

            var loginContent = SerializeToJson(query);
            HttpResponseMessage response = await Client.PostAsync($"{ApiUrl}/user/facebook", loginContent);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async void ShouldLoginByGoogle()
        {
            // Access token by test user (valid for 2 months)
            var query = new ExternalLogin.Query();
            query.AccessToken = "4%2FywGe_HfxfXHPqRS1loicyVQQgXd4KFu1T2-4AZ1QBJD76jJ2DH9kGgFxN7NC-ah_149OH9pJAt4JXkeioO2_7yg";

            var loginContent = SerializeToJson(query);
            HttpResponseMessage response = await Client.PostAsync($"{ApiUrl}/user/google", loginContent);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
