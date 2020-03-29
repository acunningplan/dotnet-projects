using System;
using System.Collections.Generic;

namespace OrderEntitiesLib
{
    public class Order
    {
        public Order() { }
        public Guid OrderID { get; set; }
        public DateTime OrderedAt { get; set; }
        public DateTime ReadyAt { get; set; }
        public DateTime FoodTakenAt { get; set; }
        public bool Cancelled { get; set; }
        public string UserId { get; set; }
        public IEnumerable<FoodOrder> FoodOrders { get; set; }
        public string FurtherDescription { get; set; }

    }
}
