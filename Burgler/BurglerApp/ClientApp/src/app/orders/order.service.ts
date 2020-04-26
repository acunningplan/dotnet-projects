import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { map, tap } from "rxjs/operators";
import { Order } from "./order";
import { OrderJson } from "./orderJson";

@Injectable({ providedIn: "root" })
export class OrderService {
  order: Order;
  constructor(private http: HttpClient) {}

  fetchPendingOrder() {
    return this.http.get<OrderJson[]>(`${environment.serverUrl}/order`).pipe(
      map((orderJson) => {
        console.log(orderJson);
      })
    );
  }

  getPendingOrder(): Order {
    return this.order;
  }
}
