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
        public DateTime OrderedAt { get; set; }
        public DateTime ReadyAt { get; set; }
        public DateTime FoodTakenAt { get; set; }
        public bool Cancelled { get; set; }
        public virtual ICollection<BurgerItemDto> BurgerItems { get; set; } = new List<BurgerItemDto>();
        public virtual ICollection<SideItemDto> SideItems { get; set; } = new List<SideItemDto>();
        public virtual ICollection<DrinkItemDto> DrinkItems { get; set; } = new List<DrinkItemDto>();
        public string FurtherDescription { get; set; } = "None";
        public double Calories { get; set; }
        public double Price { get; set; }
        public UserDto User { get; set; } = new UserDto();
    }

    public class BurgerItemDto : InitializeFoodItem
    {
        public BurgerItemDto()
        {
            Size = Patties.PattyList[0].Size;
        }
        public string BurgerBun { get; set; } = Buns.BunList[0].Name;
        public string BurgerPatty { get; set; } = Patties.PattyList[0].Name;
        public int BurgerPattyCooked { get; set; } = (int)PattyDoneness.Medium;
        public virtual ICollection<BurgerToppingDto> BurgerToppings { get; set; } = new List<BurgerToppingDto>();
    }
    public class BurgerToppingDto
    {
        public string Name { get; set; } = "Tomato";
    }
    public class DrinkItemDto : InitializeFoodItem { }
    public class SideItemDto : InitializeFoodItem { }
}
