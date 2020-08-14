import { Injectable } from "@angular/core";
import {
  Resolve,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from "@angular/router";
import { MenuService } from "./menu.service";
import { OrderService } from "../orders/order.service";

@Injectable({
  providedIn: "root",
})
export class MenuResolverService implements Resolve<void> {
  constructor(
    private menuService: MenuService,
    private orderService: OrderService
  ) {}

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (!this.menuService.getMenu()) {
      return this.menuService.fetchMenu();
    }
    return;
  }
}
