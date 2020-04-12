using Burgler.Entities.FoodItem;
using Burgler.Entities.IngredientsNS;

namespace Burgler.BusinessLogic.OrderLogic
{
    public static class BurgerItemExtensions
    {
        public static double CalculateCalories(this BurgerItem bi)
        {
            double baseCalories = 1;
            double burgerCalories = baseCalories;

            double burgerBunCalories = Buns.BunList.SelectByName(bi.BurgerBun).Calories;
            double burgerPattyCalories = Patties.PattyList.SelectByNameAndSize(bi.BurgerPatty, bi.Size).Calories;
            burgerCalories += burgerBunCalories + burgerPattyCalories;

            foreach (BurgerTopping topping in bi.BurgerToppings)
            {
                double toppingCalories = Toppings.ToppingList.SelectByName(topping.Name).Calories;
                burgerCalories += toppingCalories;
            }
            burgerCalories *= bi.Quantity;
            return burgerCalories;
        }
        public static double CalculatePrice(this BurgerItem bi)
        {
            double basePrice = 1;
            double burgerPrice = basePrice;

            double burgerBunPrice = Buns.BunList.SelectByName(bi.BurgerBun).Price;
            double burgerPattyPrice = Patties.PattyList.SelectByNameAndSize(bi.BurgerPatty, bi.Size).Price;
            burgerPrice += burgerBunPrice + burgerPattyPrice;

            foreach (BurgerTopping topping in bi.BurgerToppings)
            {
                double toppingPrice = Toppings.ToppingList.SelectByName(topping.Name).Price;
                burgerPrice += toppingPrice;
            }
            burgerPrice *= bi.Quantity;
            return burgerPrice;
        }
    }
}
