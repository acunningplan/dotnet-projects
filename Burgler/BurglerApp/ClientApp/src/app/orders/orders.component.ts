import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { OrderService } from "./order.service";
import { Order } from "./order";

@Component({
  selector: "app-orders",
  templateUrl: "./orders.component.html",
  styleUrls: ["./orders.component.css"],
})
export class OrdersComponent implements OnInit {
  constructor(private http: HttpClient, private orderService: OrderService) {}

  ngOnInit() {}

  createOrder() {
    this.orderService.updatePendingOrder(new Order());
  }
}
