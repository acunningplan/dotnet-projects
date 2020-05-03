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
export class MenuOrderResolverService implements Resolve<void> {
  constructor(
    private orderService: OrderService
  ) {}

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (!this.orderService.getPendingOrder()) {
      return this.orderService.fetchPendingOrder();
    }
    return;
  }
}
