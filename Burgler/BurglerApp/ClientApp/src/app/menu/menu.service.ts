import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { MenuJson } from "./menuJson";
import { map, tap } from "rxjs/operators";
import { Menu } from "./menu";

@Injectable({ providedIn: "root" })
export class MenuService {
  menu: Menu;
  burgerTypes: string[] = [];
  sideTypes: string[] = [];
  drinkTypes: string[] = [];
  constructor(private http: HttpClient) {}

  fetchMenu() {
    console.log("Fetching");
    return this.http.get<MenuJson>(`${environment.serverUrl}/menu`).pipe(
      map((res) => this.reformatMenu(res)),
      tap((res) => (this.menu = res))
    );
  }

  reformatMenu(menuJson: MenuJson): Menu {
    this.menu = new Menu();

    for (const burger of menuJson.burgersList) {
      if (!this.burgerTypes.find((bt) => bt == burger.type))
        this.burgerTypes.push(burger.type);
    }
    for (const burgerType of this.burgerTypes) {
      this.menu.burgers[burgerType] = menuJson.burgersList.filter(
        (b) => b.type == burgerType
      );
    }
    for (const side of menuJson.sidesList) {
      if (!this.sideTypes.find((bt) => bt == side.type))
        this.sideTypes.push(side.type);
    }
    for (const sideType of this.sideTypes) {
      this.menu.sides[sideType] = menuJson.sidesList.filter(
        (b) => b.type == sideType
      );
    }
    for (const drink of menuJson.drinksList) {
      if (!this.drinkTypes.find((bt) => bt == drink.type))
        this.drinkTypes.push(drink.type);
    }
    for (const drinkType of this.drinkTypes) {
      this.menu.drinks[drinkType] = menuJson.drinksList.filter(
        (b) => b.type == drinkType
      );
    }
    console.log(this.menu);
    return this.menu;
  }

  getMenu(): Menu {
    return this.menu;
  }

  setMenu(menu: Menu) {
    this.menu = menu;
  }
}
