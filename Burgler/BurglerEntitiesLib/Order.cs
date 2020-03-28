using System;
using System.Collections.Generic;

namespace BurglerEntitiesLib
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public DateTime OrderedAt { get; set; }
        public DateTime ReadyAt { get; set; }
        public DateTime FoodTakenAt { get; set; }
        public bool Cancelled { get; set; }
        public string User { get; set; }
        public IEnumerable<FoodOrder> FoodOrders { get; set; }
        public string FurtherDescription { get; set; }
    }
}
