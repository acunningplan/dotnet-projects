import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { MenuJson, Burger, Side, Drink } from "./menuJson";
import { map } from "rxjs/operators";
import { Menu, BurgerItem, SideItem, DrinkItem } from "./menu";
import { Ingredients, Food } from "./ingredients";
import { FoodItem } from "../orders/order";

@Injectable({ providedIn: "root" })
export class MenuService {
  private menu: Menu;
  private ingredients: Ingredients;

  constructor(private http: HttpClient) {}

  getMenu(): Menu {
    return this.menu;
  }

  getIngredients(): Ingredients {
    return this.ingredients;
  }

  fetchMenu() {
    return this.http.get<MenuJson>(`${environment.serverUrl}/menu`).pipe(
      map((menuJson) => {
        this.loadIngredients(menuJson);
        this.loadMenu(menuJson, this.ingredients);
      })
    );
  }

  private loadIngredients(menuJson: MenuJson) {
    const ingredients = new Ingredients();
    ingredients.buns = menuJson.bunsList;
    ingredients.patties = menuJson.pattiesList;
    ingredients.toppings = menuJson.toppingsList;
    this.ingredients = ingredients;
  }

  private groupBy = (array, key: string) => {
    return array.reduce((result, currentValue) => {
      (result[currentValue[key]] = result[currentValue[key]] || []).push(
        currentValue
      );
      return result;
    }, {});
  };

  private findOptions = (
    name: string,
    food: Food,
    foodList: Burger[] | Side[] | Drink[]
  ) => {
    const foodsWithName = foodList.filter((f) => f.name === name);
    if (foodsWithName.length > -1) {
      food.options = foodsWithName.map((f) => ({
        size: f.size,
        calories: f.calories,
        price: f.price,
      }));
      if ("burgerBun" in foodList[0]) {
        const b = food as BurgerItem;

        food.options = food.options.map((o) => {
          o.calories = this.calculateBurgerCalories(b, o.size);
          o.price = this.calculateBurgerPrice(b, o.size);
          return o;
        });
      }
    }
  };

  private loadMenu(menuJson: MenuJson, ingredients: Ingredients) {
    console.log(menuJson);
    const menu = new Menu();

    menu.burgerItems = menuJson.burgersList;
    menu.sideItems = menuJson.sidesList;
    menu.drinkItems = menuJson.drinksList;

    let burgers = menuJson.burgersList
      .filter(
        (burger, i) =>
          menuJson.burgersList.findIndex((b) => b.name === burger.name) === i
      )
      .map((b) => {
        const bi = new BurgerItem(b);
        this.findOptions(b.name, bi, menuJson.burgersList);
        return bi;
      });

    menu.burgers = this.groupBy(burgers, "type");

    let sides = menuJson.sidesList
      .filter(
        (side, i) =>
          menuJson.sidesList.findIndex((s) => s.name === side.name) === i
      )
      .map((s) => {
        const si = new SideItem(s);
        this.findOptions(s.name, si, menuJson.sidesList);
        return si;
      });

    menu.sides = this.groupBy(sides, "type");

    let drinks = menuJson.drinksList
      .filter(
        (drink, i) =>
          menuJson.drinksList.findIndex((d) => d.name === drink.name) === i
      )
      .map((d) => {
        const di = new DrinkItem(d);
        this.findOptions(di.name, di, menuJson.drinksList);
        return di;
      });

    menu.drinks = this.groupBy(drinks, "type");
    this.menu = menu;
  }

  calculateBurgerCalories(
    b: BurgerItem | { bun: string; patty: string; toppings: string[] },
    size: string
  ): number {
    const { bun, patty, toppings } = b;

    let totalCalories = 0;
    totalCalories += this.ingredients.buns.find((b) => b.name === bun).calories;
    totalCalories += this.ingredients.patties.find(
      (p) => p.name === patty && p.size === size
    ).calories;

    for (const topping of toppings) {
      totalCalories += this.ingredients.toppings.find((t) => t.name === topping)
        .calories;
    }
    return totalCalories;
  }

  calculateBurgerPrice(
    b: BurgerItem | { bun: string; patty: string; toppings: string[] },
    size: string
  ): number {
    const { bun, patty, toppings } = b;

    let totalPrice = 1;
    totalPrice += this.ingredients.buns.find((b) => b.name === bun).price;
    totalPrice += this.ingredients.patties.find(
      (p) => p.name === patty && p.size === size
    ).price;

    for (const topping of toppings) {
      totalPrice += this.ingredients.toppings.find((t) => t.name === topping)
        .price;
    }
    return totalPrice;
  }

  checkOneSize(foodItemName: string) {
    if (
      this.menu.burgerItems.filter((b) => b.name === foodItemName).length > 1 ||
      this.menu.sideItems.filter((s) => s.name === foodItemName).length > 1 ||
      this.menu.drinkItems.filter((d) => d.name === foodItemName).length > 1
    ) {
      return false;
    }
    return true;
  }
}
