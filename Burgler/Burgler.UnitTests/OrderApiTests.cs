using Burgler.Entities.OrderNS;
using Burgler.Entities.FoodItem;
using System.Net;
using System.Net.Http;
using Xunit;
using System.Collections.Generic;
using System;
using Burgler.BusinessLogic.OrderLogic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

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
        public async void ShouldCreateOrderWithBurgerItem()
        {
            var orderCommand = new CreateCommand();
            var orderJson = new BurgerItemJson();
            orderJson.BurgerToppings.Add("Bacon");
            orderJson.BurgerToppings.Add("Egg");
            orderCommand.BurgerItems.Add(orderJson);
            HttpResponseMessage response = await ClientWithToken.PostAsync($"{ApiUrl}/order", SerializeToJson(orderCommand));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void ShouldGetListOfOrdersByUser()
        {
            //var services = new ServiceCollection()
            //    .AddLogging((builder) => builder.AddXUnit(OutputHelper))
            //    .AddSingleton<BaseApiTests>();

            HttpResponseMessage response = await ClientWithToken.GetAsync($"{ApiUrl}/order");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();
            var orders = DeserializeString<List<Order>>(responseString);

            Assert.NotNull(orders);
        }

        [Fact]
        public async void ShouldCreateAndGetAndDelete()
        {
            var orderCommand = new CreateCommand();
            var orderJson = new BurgerItemJson();
            orderJson.BurgerToppings.Add("Bacon");
            orderCommand.BurgerItems.Add(orderJson);
            await ClientWithToken.PostAsync($"{ApiUrl}/order", SerializeToJson(orderCommand));

            HttpResponseMessage response = await ClientWithToken.GetAsync($"{ApiUrl}/order");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseString = await response.Content.ReadAsStringAsync();
            var orders = DeserializeString<List<Order>>(responseString);

            Guid id = orders[0].OrderId;
            HttpResponseMessage deleteResponse = await ClientWithToken.DeleteAsync($"{ApiUrl}/order/{id}");
            Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);
        }
    }
}
