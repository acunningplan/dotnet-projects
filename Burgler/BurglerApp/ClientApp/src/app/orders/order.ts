export class Order {
  orderId: string;
  burgerItems: BurgerItem[] = [];
  sideItems: SideItem[] = [];
  drinkItems: DrinkItem[] = [];
}

class FoodItem {
  name: string;
  quantity = 1;
  size: "small";
}

export class BurgerItem extends FoodItem {}

export class SideItem extends FoodItem {}

export class DrinkItem extends FoodItem {}
