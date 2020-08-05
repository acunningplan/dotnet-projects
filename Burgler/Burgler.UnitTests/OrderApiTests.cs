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
    public class DummyTestClass2
    {

        [Fact]
        public async void DummyTest2()
        {
            Assert.NotEqual(3, 4);
        }
    }
    //public class OrderApiTests : BaseApiTests
    //{
    //    [Fact]
    //    public async void ShouldReturnOkAfterRequestingOrders()
    //    {
    //        HttpResponseMessage response = await ClientWithToken.GetAsync($"{ApiUrl}/order");
    //        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    //        Assert.True(response.IsSuccessStatusCode);
    //    }

    //    [Fact]
    //    public async void ShouldReturnBadRequest()
    //    {
    //        var orderObject = new { SideItems = new SideItem { Name = "asdf" } };
    //        HttpResponseMessage response = await ClientWithToken.PostAsync($"{ApiUrl}/order", SerializeToJson(orderObject));
    //        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    //    }

    //    [Fact]
    //    public async void ShouldCreateOrderWithBurgerItem()
    //    {
    //        var orderCommand = new CreateCommand();
    //        var orderJson = new BurgerItemDto();
    //        //orderJson.BurgerToppings.Add(new BurgerToppingDto { Name = "Egg" });
    //        orderCommand.BurgerItems.Add(orderJson);
    //        HttpResponseMessage response = await ClientWithToken.PostAsync($"{ApiUrl}/order", SerializeToJson(orderCommand));
    //        Assert.True(response.IsSuccessStatusCode);
    //    }

    //    [Fact]
    //    public async void ShouldGetListOfOrdersByUser()
    //    {
    //        HttpResponseMessage response = await ClientWithToken.GetAsync($"{ApiUrl}/order");
    //        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    //        var responseString = await response.Content.ReadAsStringAsync();
    //        var orders = DeserializeString<List<Order>>(responseString);

    //        Assert.NotNull(orders);
    //    }

    //    [Fact]
    //    public async void ShouldDeleteAnOrderAfterCreatingOne()
    //    {
    //        // Chelsea is a staff member and is allowed to delete an order
    //        await Login("chelsea");

    //        var orderCommand = new CreateCommand();
    //        var orderJson = new BurgerItemDto();
    //        //orderJson.BurgerToppings.Add(new BurgerToppingDto { Name = "Bacon" });
    //        orderCommand.BurgerItems.Add(orderJson);
    //        await ClientWithToken.PostAsync($"{ApiUrl}/order", SerializeToJson(orderCommand));

    //        HttpResponseMessage response = await ClientWithToken.GetAsync($"{ApiUrl}/order");
    //        var responseString = await response.Content.ReadAsStringAsync();
    //        var orders = DeserializeString<List<Order>>(responseString);

    //        Guid id = orders[0].OrderId;
    //        HttpResponseMessage deleteResponse = await ClientWithToken.DeleteAsync($"{ApiUrl}/order/{id}");
    //        Assert.True(deleteResponse.IsSuccessStatusCode);
    //    }
}
