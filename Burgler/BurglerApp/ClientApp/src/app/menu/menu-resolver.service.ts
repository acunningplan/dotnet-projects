import { Injectable } from "@angular/core";
import {
  Resolve,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from "@angular/router";
import { Menu } from "./menu";
import { MenuService } from "./menu.service";
import { MenuJson } from "./menuJson";

@Injectable({
  providedIn: "root",
})
export class MenuResolverService implements Resolve<Menu> {
  constructor(private menuService: MenuService) {}

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const menu = this.menuService.getMenu();
    if (menu == null) {
      return this.menuService.fetchMenu();
    } else return menu;
  }
}
