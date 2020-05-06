import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { MenuJson } from "./menuJson";
import { map, tap } from "rxjs/operators";
import { Menu, BurgerItem, SideItem, DrinkItem } from "./menu";
import { Ingredients } from "./ingredients";

@Injectable({ providedIn: "root" })
export class MenuService {
  menu: Menu;
  ingredients: Ingredients;

  constructor(private http: HttpClient) {}

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

  private loadMenu(menuJson: MenuJson, ingredients: Ingredients) {
    const menu = new Menu();

    console.log(menuJson);

    let burgers = menuJson.burgersList;
    // .filter(
    //   (burger, i) =>
    //     menuJson.burgersList.findIndex((b) => b.name === burger.name) === i
    // )
    // .map((b) => {
    //   const bi = new BurgerItem(b, ingredients);
    //   bi.options = menuJson.burgersList
    //     .filter((burger) => burger.name === b.name)
    //     .map((b) => ({ size: b.size, calories: b.calories, price: b.price }));
    //   return bi;
    // });

    menu.burgers = this.groupBy(burgers, "type");

    let sides = menuJson.sidesList
      .filter(
        (side, i) =>
          menuJson.sidesList.findIndex((s) => s.name === side.name) === i
      )
      .map((s) => {
        const si = new SideItem(s);
        si.options = menuJson.sidesList
          .filter((side) => side.name === s.name)
          .map((s) => ({ size: s.size, calories: s.calories, price: s.price }));
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
        return di;
      });

    menu.drinks = this.groupBy(drinks, "type");

    // for (const burger of menuJson.burgersList) {
    //   if (!burgerTypes.find((bt) => bt == burger.type))
    //     burgerTypes.push(burger.type);
    // }
    // for (const burgerType of burgerTypes) {
    //   menu.burgers[burgerType] = menuJson.burgersList
    //     .filter((b) => b.type == burgerType)
    //     .map((b) => new BurgerItem(b, ingredients));
    // }
    // for (const side of menuJson.sidesList) {
    //   if (!sideTypes.find((st) => st == side.type)) sideTypes.push(side.type);
    // }
    // for (const sideType of sideTypes) {
    //   menu.sides[sideType] = menuJson.sidesList.filter(
    //     (b) => b.type == sideType
    //   );
    // }

    // for (const drink of drinks) {
    //   if (!drinkTypes.find((dt) => dt == drink.type))
    //     drinkTypes.push(drink.type);
    // }
    // for (const drinkType of drinkTypes) {
    //   menu.drinks[drinkType] = menuJson.drinksList.filter(
    //     (b) => b.type == drinkType
    //   );
    // }

    this.menu = menu;
  }

  getMenu(): Menu {
    return this.menu;
  }

  setMenu(menu: Menu) {
    this.menu = menu;
  }
}
