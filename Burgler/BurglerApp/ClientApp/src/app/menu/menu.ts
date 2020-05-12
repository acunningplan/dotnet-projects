import { Burger, Drink, Side } from "./menuJson";
import { Ingredient, Ingredients, Food } from "./ingredients";

export class Menu {
  burgers: { [key: string]: BurgerItem[] } = {};
  sides: { [key: string]: SideItem[] } = {};
  drinks: { [key: string]: DrinkItem[] } = {};

  burgerItems: BurgerItem[];
  sideItems: SideItem[];
  drinkItems: DrinkItem[];
}

export class BurgerItem extends Food {
  constructor(burger: Burger, ingredients: Ingredients) {
    super();
    this.name = burger.name;
    this.type = burger.type;
    this.description = burger.description;
    this.ingredients = ingredients;
    this.bun = burger.burgerBun;
    this.toppings = burger.burgerToppings.split("+");
    this.patty = burger.burgerPatty;
    // this.calculateCalories();
    // this.calculatePrice();
  }
  type: string;
  ingredients: Ingredients;
  bun: string;
  patty: string;
  toppings: string[];

  // private calculateCalories() {
  //   this.calories += this.ingredients.buns.find(
  //     (b) => b.name === this.bun
  //   ).calories;
  //   this.ingredients.toppings
  //     .filter((t) => this.toppings.includes(t.name))
  //     .forEach((t) => (this.calories += t.calories));
  //   this.calories += this.ingredients.patties.find(
  //     (p) => p.name === this.patty
  //   ).calories;
  // }

  // private calculatePrice() {
  //   this.price += this.ingredients.buns.find((b) => b.name === this.bun).price;
  //   this.ingredients.toppings
  //     .filter((t) => this.toppings.includes(t.name))
  //     .forEach((t) => (this.price += t.price));
  //   this.price += this.ingredients.patties.find(
  //     (p) => p.name === this.patty
  //   ).price;
  // }
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
