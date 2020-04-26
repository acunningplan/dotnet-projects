import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { MenuJson } from "./menuJson";
import { map, tap } from "rxjs/operators";
import { Menu, BurgerItem } from "./menu";
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

  private loadMenu(menuJson: MenuJson, ingredients: Ingredients) {
    const menu = new Menu();
    const burgerTypes: string[] = [];
    const sideTypes: string[] = [];
    const drinkTypes: string[] = [];
    for (const burger of menuJson.burgersList) {
      if (!burgerTypes.find((bt) => bt == burger.type))
        burgerTypes.push(burger.type);
    }
    for (const burgerType of burgerTypes) {
      menu.burgers[burgerType] = menuJson.burgersList
        .filter((b) => b.type == burgerType)
        .map((b) => new BurgerItem(b, ingredients));
    }
    for (const side of menuJson.sidesList) {
      if (!sideTypes.find((bt) => bt == side.type)) sideTypes.push(side.type);
    }
    for (const sideType of sideTypes) {
      menu.sides[sideType] = menuJson.sidesList.filter(
        (b) => b.type == sideType
      );
    }
    for (const drink of menuJson.drinksList) {
      if (!drinkTypes.find((bt) => bt == drink.type))
        drinkTypes.push(drink.type);
    }
    for (const drinkType of drinkTypes) {
      menu.drinks[drinkType] = menuJson.drinksList.filter(
        (b) => b.type == drinkType
      );
    }
    this.menu = menu;
  }

  getMenu(): Menu {
    return this.menu;
  }

  setMenu(menu: Menu) {
    this.menu = menu;
  }
}
