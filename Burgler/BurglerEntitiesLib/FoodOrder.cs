using System;
using System.Collections.Generic;
using System.Text;

namespace OrderEntitiesLib
{
    public class FoodOrder
    {
        public Guid FoodOrderId { get; set; }
        public int Quantity { get; set; }
    }
}
