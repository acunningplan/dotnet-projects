import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { map, tap } from "rxjs/operators";
import { Order } from "./order";
import { OrderJson } from "./orderJson";

@Injectable({ providedIn: "root" })
export class OrderService {
  pendingOrder: Order;
  constructor(private http: HttpClient) {}

  // Get pending order
  fetchPendingOrder() {
    return this.http.get<OrderJson[]>(`${environment.serverUrl}/order`).pipe(
      map((orderJson) => {
        if (orderJson.length === 0) {
          // Create new order if there's no pending order
          this.pendingOrder = new Order();
          this.http.post(`${environment.serverUrl}/order`, {});
        } else {
          // If pending order is found, load it to service
          this.loadPendingOrder(orderJson[0]);
        }
        console.log("Logging fetched pending order:");
        console.log(orderJson);
      })
    );
  }

  getPendingOrder(): Order {
    return this.pendingOrder;
  }

  loadPendingOrder(orderJson: OrderJson) {
    const pendingOrder = new Order();
    if (!!orderJson) {
      pendingOrder.burgerItems = orderJson.burgerItems;
      pendingOrder.sideItems = orderJson.sideItems;
      pendingOrder.drinkItems = orderJson.drinkItems;
    }
    this.pendingOrder = pendingOrder;
  }

  updatePendingOrder(pendingOrder: Order) {
    this.pendingOrder = pendingOrder;
    const pendingOrderJson = new OrderJson();
    pendingOrderJson.burgerItems = pendingOrder.burgerItems;
    pendingOrderJson.sideItems = pendingOrder.sideItems;
    pendingOrderJson.drinkItems = pendingOrder.drinkItems;
    this.http
      .post(`${environment.serverUrl}/order`, pendingOrderJson)
      .subscribe((res) => console.log(res));
  }
}
