import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { MenuJson, Burger, Side, Drink } from "./menuJson";
import { map } from "rxjs/operators";
import { Menu, BurgerItem, SideItem, DrinkItem } from "./menu";
import { Ingredients, Food } from "./ingredients";

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
    ingredients.patties = menuJson.pattiesList.filter(
      (patty, i) =>
        menuJson.pattiesList.findIndex((p) => p.name === patty.name) === i
    );
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
    }
  };

  private loadMenu(menuJson: MenuJson, ingredients: Ingredients) {
    console.log(menuJson);
    const menu = new Menu();

    let burgers = menuJson.burgersList
      .filter(
        (burger, i) =>
          menuJson.burgersList.findIndex((b) => b.name === burger.name) === i
      )
      .map((b) => {
        const bi = new BurgerItem(b, ingredients);
        // bi.options = menuJson.burgersList
        //   .filter((burger) => burger.name === b.name)
        //   .map((b) => ({ size: b.size, calories: b.calories, price: b.price }));

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
        // si.options = menuJson.sidesList
        //   .filter((side) => side.name === s.name)
        //   .map((s) => ({ size: s.size, calories: s.calories, price: s.price }));
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
        di.options = menuJson.drinksList
          .filter((drink) => drink.name === d.name)
          .map((d) => ({ size: d.size, calories: d.calories, price: d.price }));
        // this.findOptions(di.name, di, menuJson.drinksList);
        return di;
      });

    menu.drinks = this.groupBy(drinks, "type");
    this.menu = menu;
  }

  // calories: number;
  // price: number;
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
