import { Component, OnInit, Input } from "@angular/core";
import { Order } from "../order";
import { OrderService } from "../order.service";
import { OrderConfirmationService } from "../order-confirmation/order-confirmation.service";

@Component({
  selector: "app-order-detail",
  templateUrl: "./order-detail.component.html",
  styleUrls: ["./order-detail.component.css"],
})
export class OrderDetailComponent implements OnInit {
  @Input() order: Order;
  @Input() status: string;

  constructor(
    private orderService: OrderService,
    private orderConfirmationService: OrderConfirmationService
  ) {}

  ngOnInit(): void {}

  cancelOrder(orderId: string) {
    this.orderService
      .changeOrderStatus(orderId, "cancel")
      .subscribe(() => location.reload());
  }

  placeOrder() {
    this.orderService
      .changeOrderStatus(this.order.orderId, "placeOrder")
      .subscribe(() => location.reload());
  }

  confirmOrder(mode: string) {
    this.orderConfirmationService.orderConfirmationSubject.next({
      order: this.order,
      mode,
    });
  }
}
