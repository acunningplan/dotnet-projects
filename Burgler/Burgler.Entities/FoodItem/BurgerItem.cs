using Burgler.Entities.IngredientsNS;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Burgler.Entities.FoodItem
{
    public class BurgerItem : InitializeFoodItem
    {
        public BurgerItem()
        {
            Size = Patties.PattyList[0].Size;
        }
        public Guid BurgerItemId { get; set; }
        public string BurgerBun { get; set; } = Buns.BunList[0].Name;
        public string BurgerPatty { get; set; } = Patties.PattyList[0].Name;
        public PattyDoneness BurgerPattyCooked { get; set; } = PattyDoneness.Medium;
        public virtual ICollection<BurgerTopping> BurgerToppings { get; set; } = new List<BurgerTopping>();
        public Guid OrderId { get; set; }
        public virtual OrderNS.Order Order { get; set; }
    }
}
