import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { OrderService } from "./order.service";
import { Order } from "./order";
import * as moment from "moment";

@Component({
  selector: "app-orders",
  templateUrl: "./orders.component.html",
  styleUrls: ["./orders.component.css"],
})
export class OrdersComponent implements OnInit {
  pendingOrder: Order;
  orders: Order[];
  constructor(private http: HttpClient, private orderService: OrderService) {
    this.pendingOrder = orderService.getPendingOrder();
    this.orders = orderService.getPastOrders();
  }

  ngOnInit() {}

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
    return moment(dateTime).format("MMMM Do YYYY, h:mm");
  }
}
