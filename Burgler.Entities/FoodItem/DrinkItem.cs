using System;

namespace Burgler.Entities.FoodItem
{
    public class DrinkItem : FoodItem
    {
        public Guid DrinkItemId { get; set; }
        public Guid OrderId { get; set; }
        public virtual OrderNS.Order Order { get; set; }
    }
}
