using Burgler.Entities.FoodItem;
using Burgler.Entities.Ingredients;
using Burgler.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Burgler.Entities.OrderNS
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime OrderedAt { get; set; }
        public DateTime LastEditedAt { get; set; }
        public DateTime ReadyAt { get; set; }
        public DateTime FoodTakenAt { get; set; }
        public DateTime CancelledAt { get; set; }
        public DateTime PickupTime { get; set; }
        public virtual ICollection<BurgerItem> BurgerItems { get; set; } = new List<BurgerItem>();
        public virtual ICollection<SideItem> SideItems { get; set; } = new List<SideItem>();
        public virtual ICollection<DrinkItem> DrinkItems { get; set; } = new List<DrinkItem>();
        public string OrderDescription { get; set; } = "None";
        public double Calories { get; set; }
        public double Price { get; set; }
        public Guid UserId { get; set; }
        public virtual AppUser User { get; set; }
    }
}
