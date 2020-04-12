using Burgler.Entities.IngredientsNS;
using System;
using System.Collections.Generic;

namespace Burgler.Entities.FoodItem
{
    public class BurgerItem : InitializeFoodItem
    {
        public Guid BurgerItemId { get; set; }
        public string BurgerBun { get; set; }
        public string BurgerPatty { get; set; }
        public string BurgerPattySize { get; set; }
        public PattyDoneness BurgerPattyCooked { get; set; }
        public virtual ICollection<BurgerTopping> BurgerToppings { get; set; } = new List<BurgerTopping>();
        public Guid OrderId { get; set; }
        public virtual OrderNS.Order Order { get; set; }
    }
}
