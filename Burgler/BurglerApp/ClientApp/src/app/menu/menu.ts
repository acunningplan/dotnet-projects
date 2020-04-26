import { Burger } from "./menuJson";
import { Ingredient, Ingredients } from "./ingredients";

export class Menu {
  burgers: { [key: string]: BurgerItem[] } = {};
  sides: { [key: string]: SideItem[] } = {};
  drinks: { [key: string]: DrinkItem[] } = {};
}

export class BurgerItem extends Ingredient {
  constructor(burger: Burger, ingredients: Ingredients) {
    super();
    this.ingredients = ingredients;
    this.bun = burger.burgerBun;
    this.toppings = burger.burgerToppings.split("+");
    this.patty = burger.burgerPatty;
    this.calculateCalories();
    this.calculatePrice();
  }

  private ingredients: Ingredients;
  bun: string;
  patty: string;
  toppings: string[];
  calories = 0;
  price = 1;

  private calculateCalories() {
    this.calories += this.ingredients.buns.find(
      (b) => b.name === this.bun
    ).calories;
    this.ingredients.toppings
      .filter((t) => this.toppings.includes(t.name))
      .forEach((t) => (this.calories += t.calories));
    this.calories += this.ingredients.patties.find(
      (p) => p.name === this.patty
    ).calories;
  }

  private calculatePrice() {
    this.price += this.ingredients.buns.find((b) => b.name === this.bun).price;
    this.ingredients.toppings
      .filter((t) => this.toppings.includes(t.name))
      .forEach((t) => (this.price += t.price));
    this.price += this.ingredients.patties.find(
      (p) => p.name === this.patty
    ).price;
  }
}

class SideItem extends Ingredient {
  size: string;
  type: string;
}

class DrinkItem extends Ingredient {
  size: string;
  type: string;
  volume: string;
}
