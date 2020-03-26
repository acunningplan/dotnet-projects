using System;
using System.Collections.Generic;

namespace BurglerEntitiesLib
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; }
        public IEnumerable<FoodOrder> FoodOrders { get; set; }
        public string FurtherDescription { get; set; }
    }
}
