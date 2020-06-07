import { Burger, Drink, Side } from "./menuJson";
import { Ingredient, Ingredients, Food } from "./ingredients";

export class Menu {
  burgers: { [key: string]: BurgerItem[] } = {};
  sides: { [key: string]: SideItem[] } = {};
  drinks: { [key: string]: DrinkItem[] } = {};

  burgerItems: Burger[];
  sideItems: Side[];
  drinkItems: Drink[];
}

export class BurgerItem extends Food {
  constructor(burger?: Burger) {
    super();
    if (!!burger) {
      
      this.name = burger.name;
      this.type = burger.type;
      this.description = burger.description;
      this.bun = burger.burgerBun;
      this.toppings = burger.burgerToppings.split("+");
      this.patty = burger.burgerPatty;
      this.pattyCooked = "Well done";
    }
  }
  type: string;
  bun: string;
  patty: string;
  pattyCooked = "Well done";
  toppings: string[];
}

export class SideItem extends Food {
  constructor(side: Side) {
    super();
    this.name = side.name;
    this.type = side.type;
    this.description = side.description;
  }
  type: string;
}

export class DrinkItem extends Food {
  constructor(drink: Drink) {
    super();
    this.name = drink.name;
    this.type = drink.type;
    this.volume = drink.volume;
    this.description = drink.description;
  }
  type: string;
  volume: string;
}
