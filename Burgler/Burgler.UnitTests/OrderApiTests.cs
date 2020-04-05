using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Burgler.UnitTests
{
    public class OrderApiTests : BaseApiTests
    {
        [Fact]
        public async void ShouldReturnOkAfterRequestingOrders()
        {
            string username = "sarah";
            HttpResponseMessage response = await Client.GetAsync($"{ApiUrl}/order/user/{username}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void ShouldReturnBadRequest()
        {
            HttpResponseMessage response = await ClientWithToken.PostAsync($"{ApiUrl}/order", LoginResponse.Content);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
