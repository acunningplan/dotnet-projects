import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { HttpClientModule } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { map, tap } from "rxjs/operators";
import { Order } from "./order";
import { OrderJson } from "./orderJson";

@Injectable({ providedIn: "root" })
export class OrderService {
  private pendingOrder: Order;
  private pastOrders: Order[];
  constructor(private http: HttpClient) {}

  // Fetch and pre-load pending order
  fetchPendingOrder() {
    return this.http.get<OrderJson[]>(`${environment.serverUrl}/order`).pipe(
      map((orderJson) => {
        if (orderJson.length === 0) {
          // Create new order if there's no pending order
          this.pendingOrder = new Order();
          this.http.post(`${environment.serverUrl}/order`, {});
        } else {
          // If pending order is found, load it to service
          this.pendingOrder = new Order(orderJson[0]);
        }
        console.log(orderJson);
      })
    );
  }

  fetchPastOrders() {
    return this.http
      .get<OrderJson[]>(`${environment.serverUrl}/order/placed`)
      .pipe(
        map((orderJson) => {
          this.pastOrders = orderJson.map((o) => new Order(o));
          console.log("Logging past orders:");
          console.log(this.pastOrders);
        })
      );
  }

  getPendingOrder(): Order {
    return this.pendingOrder;
  }

  getPastOrders(): Order[] {
    return this.pastOrders;
  }

  updatePendingOrder(pendingOrder: Order) {
    this.pendingOrder = pendingOrder;
    this.http
      .patch(`${environment.serverUrl}/order/edit`, pendingOrder)
      .subscribe((res) => console.log(res));
  }

  changeOrderStatus(orderId: string, action: string) {
    let statusChange: number;
    if (action === "placeOrder") {
      statusChange = 0;
    } else if (action === "cancel") {
      statusChange = 1;
    }
    this.http
      .patch(
        `${environment.serverUrl}/order/change/${orderId}`,
        {
          statusChange,
        },
        { observe: "response" }
      )
      .subscribe((res) => {
        console.log(res.status);
      });
  }
}
