using Burgler.Entities.FoodItem;
using Burgler.Entities.User;
using System;
using System.Collections.Generic;

namespace Burgler.Entities.OrderNS
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public DateTime OrderedAt { get; set; }
        public DateTime ReadyAt { get; set; }
        public DateTime FoodTakenAt { get; set; }
        public bool Cancelled { get; set; }
        public virtual ICollection<BurgerItem> BurgerItems { get; set; }
        public virtual ICollection<SideItem> SideItems { get; set; }
        public virtual ICollection<DrinkItem> DrinkItems { get; set; }
        public string FurtherDescription { get; set; }
        public UserDto User { get; set; }
    }
}
