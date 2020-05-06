import { Food } from "../menu/ingredients";

export class Order {
  orderId: string;
  burgerItems: BurgerItem[] = [];
  sideItems: SideItem[] = [];
  drinkItems: DrinkItem[] = [];
}

export class FoodItem {
  name: string;
  quantity = 1;
  size = "Small";

  constructor(
    food: Food,
    option: { size: string; price: number; calories: number }
  ) {
    this.name = food.name;
    this.size = option.size;
  }
}

export class BurgerItem extends FoodItem {}

export class SideItem extends FoodItem {}

export class DrinkItem extends FoodItem {}
