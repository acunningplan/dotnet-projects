using Burgler.Entities.FoodItem;
using Burgler.Entities.IngredientsNS;
using Burgler.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.BusinessLogic.OrderLogic
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public string Status { get; set; }
        public DateTime OrderedAt { get; set; }
        //public DateTime EditedAt { get; set; }
        //public DateTime ReadyAt { get; set; }
        //public DateTime FoodTakenAt { get; set; }
        public DateTime PickupTime { get; set; }
        //public DateTime CancelledAt { get; set; }
        public virtual ICollection<BurgerItemDto> BurgerItems { get; set; } = new List<BurgerItemDto>();
        public virtual ICollection<SideItemDto> SideItems { get; set; } = new List<SideItemDto>();
        public virtual ICollection<DrinkItemDto> DrinkItems { get; set; } = new List<DrinkItemDto>();
        public string OrderDescription { get; set; } = "None";
        public double Calories { get; set; }
        public double Price { get; set; }
        public UserDto User { get; set; } = new UserDto();
    }

    public class BurgerItemDto : FoodItem
    {
        public BurgerItemDto()
        {
            Size = "Small";
        }
        public string BurgerBun { get; set; } = "White";
        public string BurgerPatty { get; set; } = "Beef";
        public string BurgerPattyCooked { get; set; } = "Medium";
        public virtual string BurgerToppings { get; set; } = "Tomato+Lettuce";
    }
    //public class BurgerToppingDto
    //{
    //    public string Name { get; set; } = "Tomato";
    //}
    public class DrinkItemDto : FoodItem { }
    public class SideItemDto : FoodItem { }
}
