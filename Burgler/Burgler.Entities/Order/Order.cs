using Burgler.Entities.FoodItem;
using Burgler.Entities.User;
using System;
using System.Collections.Generic;

namespace Burgler.Entities.OrderNS
{
    public class Order
    {
        public Order()
        {
            BurgerItems = new List<BurgerItem>();
            SideItems = new List<SideItem>();
            DrinkItems = new List<DrinkItem>();
        }
        public Guid OrderID { get; set; }
        public DateTime OrderedAt { get; set; }
        public DateTime ReadyAt { get; set; }
        public DateTime FoodTakenAt { get; set; }
        public bool Cancelled { get; set; }
        public string UserId { get; set; }
        public virtual IEnumerable<BurgerItem> BurgerItems { get; set; }
        public virtual IEnumerable<SideItem> SideItems { get; set; }
        public virtual IEnumerable<DrinkItem> DrinkItems { get; set; }
        public string FurtherDescription { get; set; }
        public virtual AppUser User { get; set; }
    }
}
