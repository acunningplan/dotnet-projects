import { Food } from "../menu/ingredients";
import { OrderJson } from "./orderJson";
import { BurgerItem } from "../menu/menu";

export class Order {
  constructor(orderJson?: OrderJson) {
    if (!!orderJson) {
      this.orderId = orderJson.orderId;
      this.orderedAt = orderJson.orderedAt;

      this.status = orderJson.status;
      this.burgerItems = orderJson.burgerItems;
      this.sideItems = orderJson.sideItems;
      this.drinkItems = orderJson.drinkItems;
    }
  }
  orderId: string;
  orderedAt: Date;
  status: string;
  burgerItems: BurgerItemJson[] = [];
  sideItems: SideItemJson[] = [];
  drinkItems: DrinkItemJson[] = [];
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

export class BurgerItemJson extends FoodItem {
  constructor(
    burger: BurgerItem,
    option: { size: string; price: number; calories: number }
  ) {
    super(burger, option);
    this.burgerBun = burger.bun;
    this.burgerToppings = burger.toppings.join("+");
    this.burgerPatty = burger.patty;
  }
  burgerBun: string;
  burgerToppings: string;
  burgerPatty: string;
}

export class SideItemJson extends FoodItem {}

export class DrinkItemJson extends FoodItem {}
