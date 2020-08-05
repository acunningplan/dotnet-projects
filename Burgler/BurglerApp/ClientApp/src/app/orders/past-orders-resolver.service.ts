import { Injectable } from "@angular/core";
import {
  Resolve,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from "@angular/router";
import { OrderService } from "./order.service";

@Injectable({
  providedIn: "root",
})
export class PastOrdersResolverService implements Resolve<void> {
  constructor(private orderService: OrderService) {}

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (!this.orderService.getPastOrders()) {
      return this.orderService.fetchPastOrders();
    } else return;
  }
}
