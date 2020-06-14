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

      this.customItemCount = orderJson.customItemCount;
    }
  }
  customItemCount = 1;
  orderId: string;
  orderedAt: Date;
  status: string;
  burgerItems: BurgerItemJson[] = [];
  sideItems: SideItemJson[] = [];
  drinkItems: DrinkItemJson[] = [];
  totalPrice: string;
}

export class FoodItem {
  name: string;
  price: number;
  calories: number;
  quantity = 1;
  size = "Small";
  customId?: number;

  constructor(
    food: Food,
    option: { size: string; price: number; calories: number },
    quantity?: number
  ) {
    this.name = food.name;
    this.size = option.size;
    this.price = option.price;
    this.quantity = quantity ?? 1;
  }
}

export class BurgerItemJson extends FoodItem {
  constructor(
    burger: BurgerItem,
    option: { size: string; price: number; calories: number },
    quantity?: number
  ) {
    super(burger, option, quantity);
    this.burgerBun = burger.bun;
    this.burgerToppings = burger.toppings.join("+");
    this.burgerToppingsArray = burger.toppings;
    this.burgerPatty = burger.patty;
    this.burgerPattyCooked = burger.pattyCooked;
  }
  burgerBun: string;
  burgerToppings: string;
  burgerToppingsArray: string[];
  burgerPatty: string;
  burgerPattyCooked: string;

  addOrRemoveTopping(topping: string) {
    if (!this.burgerToppingsArray.find((bt) => bt === topping)) {
      this.burgerToppingsArray.push(topping);
      this.burgerToppings = this.burgerToppingsArray.join("+");
    } else {
      this.burgerToppingsArray = this.burgerToppingsArray.filter(
        (bt) => bt !== topping
      );
      this.burgerToppings = this.burgerToppingsArray.join("+");
    }
  }
}

export class SideItemJson extends FoodItem {}

export class DrinkItemJson extends FoodItem {}
