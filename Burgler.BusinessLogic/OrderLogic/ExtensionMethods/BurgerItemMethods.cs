using Burgler.BusinessLogic.MenuLogic;
using Burgler.Entities.FoodItem;

namespace Burgler.BusinessLogic.OrderLogic
{
    public static class BurgerItemMethods
    {
        public static double CalculateCalories(Menu menu, BurgerItem bi)
        {
            double baseCalories = 1;
            double burgerCalories = baseCalories;

            double burgerBunCalories = menu.BunsList
                .Find(bun => bun.Name == bi.BurgerBun).Calories;
            double burgerPattyCalories = menu.PattiesList
                .Find(patty => patty.Name == bi.BurgerPatty & patty.Size == bi.Size).Calories;
            burgerCalories += burgerBunCalories + burgerPattyCalories;

            var toppingNames = bi.BurgerToppings.Split("+");
            foreach (string toppingName in toppingNames)
            {
                double toppingCalories = menu.ToppingsList
                    .Find(topping => topping.Name == toppingName).Calories;
                burgerCalories += toppingCalories;
            }
            burgerCalories *= bi.Quantity;
            return burgerCalories;
        }
        public static double CalculatePrice(Menu menu, BurgerItem bi)
        {
            double basePrice = 1;
            double burgerPrice = basePrice;

            double burgerBunPrice = menu.BunsList
                .Find(bun => bun.Name == bi.BurgerBun).Price;
            double burgerPattyPrice = menu.PattiesList
                .Find(patty => patty.Name == bi.BurgerPatty & patty.Size == bi.Size).Price;
            burgerPrice += burgerBunPrice + burgerPattyPrice;

            var toppingNames = bi.BurgerToppings.Split("+");
            foreach (string toppingName in toppingNames)
            {
                double toppingPrice = menu.ToppingsList
                    .Find(topping => topping.Name == toppingName).Price;
                burgerPrice += toppingPrice;
            }
            burgerPrice *= bi.Quantity;
            return burgerPrice;
        }
    }
}
