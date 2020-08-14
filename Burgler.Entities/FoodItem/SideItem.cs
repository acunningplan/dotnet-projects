using Burgler.Entities.Ingredients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.FoodItem
{
    public class SideItem : FoodItem
    {
        public Guid SideItemId { get; set; }
        public Guid OrderId { get; set; }
        public virtual OrderNS.Order Order { get; set; }
    }
}
