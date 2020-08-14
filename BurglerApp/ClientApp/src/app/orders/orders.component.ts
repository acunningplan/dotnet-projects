import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { OrderService } from "./order.service";
import { Order } from "./order";
import * as moment from "moment";
import { LoadingService } from "../loading/loading.service";

@Component({
  selector: "app-orders",
  templateUrl: "./orders.component.html",
  styleUrls: ["./orders.component.css"],
})
export class OrdersComponent implements OnInit {
  pendingOrder: Order;
  orders: Order[];
  totalPrice = "";
  constructor(private http: HttpClient, private orderService: OrderService, private loadingService: LoadingService) {}

  ngOnInit() {
    this.pendingOrder = this.orderService.getPendingOrder();
    this.orders = this.orderService.getPastOrders();
    this.pendingOrder.totalPrice = this.orderService.calculateOrderPrice();
    this.orders = this.orders.map((o) => {
      o.totalPrice = this.orderService.calculateOrderPrice(o);
      return o;
    });
    this.loadingService.loadingSubject.next({ loading: false });
  }

  getOrders() {}

  // createOrder() {
  //   this.orderService.updatePendingOrder(new Order());
  // }

  cancelOrder(orderId: string) {
    this.orderService
      .changeOrderStatus(orderId, "cancel")
      .subscribe(() => location.reload());
  }

  placeOrder() {
    this.orderService
      .changeOrderStatus(this.pendingOrder.orderId, "placeOrder")
      .subscribe(() => location.reload());
  }

  reformatDateTime(dateTime: Date) {
    return moment(dateTime).format("MMMM Do YYYY, h:mmA");
  }
}
