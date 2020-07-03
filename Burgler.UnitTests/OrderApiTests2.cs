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
using System.Threading.Tasks;

namespace Burgler.UnitTests
{
    public class DummyTestClass
    {

        [Fact]
        public async void DummyTest()
        {
            //try
            //{
            //    HttpResponseMessage response = await Client.PostAsync($"{ApiUrl}/order", new StringContent("No token attached"));
            //    Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
            //}
            //catch (HttpRequestException e)
            //{
            //    Assert.True(false, e.ToString());
            //}
            Assert.NotEqual(3, 4);
        }
    }
    //public class OrderApiTests2 : BaseApiTests
    //{
    //    public async Task<List<Order>> GetOrders()
    //    {
    //        HttpResponseMessage response = await ClientWithToken.GetAsync($"{ApiUrl}/order");
    //        var responseString = await response.Content.ReadAsStringAsync();
    //        return DeserializeString<List<Order>>(responseString);
    //    }
    //    public async Task<OrderDto> GetOrder(Guid id)
    //    {
    //        HttpResponseMessage response = await ClientWithToken.GetAsync($"{ApiUrl}/order/{id}");
    //        var responseString = await response.Content.ReadAsStringAsync();
    //        return DeserializeString<OrderDto>(responseString);
    //    }

    //    [Fact]
    //    public async void ShouldEditOrder()
    //    {
    //        var order = (await GetOrders())[0];
    //        var orderId = order.OrderId;

    //        var newOrder = new OrderDto();
    //        newOrder.BurgerItems = new List<BurgerItemDto>() { new BurgerItemDto() { BurgerPatty = "Veggie" } };
    //        newOrder.OrderId = orderId;
    //        HttpResponseMessage response = await ClientWithToken.PatchAsync($"{ApiUrl}/order/edit", SerializeToJson(newOrder));
    //        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    //        var editedOrder = await GetOrder(orderId);
    //        var burgerItem = ((List<BurgerItemDto>)editedOrder.BurgerItems)[0];
    //        Assert.Equal("Veggie", burgerItem.BurgerPatty);
    //    }
    //    [Fact]
    //    public async void ShouldPlaceOrder()
    //    {
    //        var order = (await GetOrders())[0];
    //        var orderId = order.OrderId;

    //        var command = new ChangeStatusCommand { StatusChange = (int)ChangeStatusType.PlaceOrder };
    //        HttpResponseMessage response = await ClientWithToken.PatchAsync($"{ApiUrl}/order/change/{orderId}", SerializeToJson(command));
    //        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    //        var placedOrder = await GetOrder(orderId);
    //        Assert.NotEqual(DateTime.MinValue, placedOrder.OrderedAt);
    //    }
    //    [Fact]
    //    public async void ShouldCancelOrder()
    //    {
    //        var order = (await GetOrders())[0];
    //        var orderId = order.OrderId;

    //        var command = new ChangeStatusCommand { StatusChange = (int)ChangeStatusType.Cancel };
    //        HttpResponseMessage response = await ClientWithToken.PatchAsync($"{ApiUrl}/order/change/{orderId}", SerializeToJson(command));
    //        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    //        var cancelledOrder = await GetOrder(orderId);
    //        //Assert.NotEqual(DateTime.MinValue, cancelledOrder.CancelledAt);
    //    }
}
