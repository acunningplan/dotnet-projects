using Burgler.Entities.OrderNS;
using Burgler.Entities.FoodItem;
using System.Net;
using System.Net.Http;
using Xunit;
using System.Collections.Generic;
using System;

namespace Burgler.UnitTests
{
    public class OrderApiTests : BaseApiTests
    {
        [Fact]
        public async void ShouldReturnOkAfterRequestingOrders()
        {
            HttpResponseMessage response = await ClientWithToken.GetAsync($"{ApiUrl}/order");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void ShouldReturnBadRequest()
        {
            var orderObject = new { bad_Content = "asdf" };
            HttpResponseMessage response = await ClientWithToken.PostAsync($"{ApiUrl}/order", SerializeToJson(orderObject));
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async void ShouldCreateOrderWithDefaultBurgerItem()
        {
            var orderObject = new Order { BurgerItems = new List<BurgerItem> { new BurgerItem() } };
            HttpResponseMessage response = await ClientWithToken.PostAsync($"{ApiUrl}/order", SerializeToJson(orderObject));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void ShouldGetListOfOrdersByUser()
        {
            HttpResponseMessage response = await ClientWithToken.GetAsync($"{ApiUrl}/order");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();
            try
            {
                var orders = DeserializeString<List<Order>>(responseString);
                Assert.NotNull(orders);
            }
            catch (Exception e)
            {
                Assert.True(false, e.ToString());
            }
        }

        [Fact]
        public async void ShouldCreateAndGetAndDelete()
        {
            var orderObject = new Order { BurgerItems = new List<BurgerItem> { new BurgerItem() } };
            await ClientWithToken.PostAsync($"{ApiUrl}/order", SerializeToJson(orderObject));

            HttpResponseMessage response = await ClientWithToken.GetAsync($"{ApiUrl}/order");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseString = await response.Content.ReadAsStringAsync();
            var orders = DeserializeString<List<Order>>(responseString);

            Guid id = orders[0].OrderID;
            HttpResponseMessage deleteResponse = await ClientWithToken.DeleteAsync($"{ApiUrl}/order/{id}");
            Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);
        }
    }
}
