import { Component, OnInit, Input } from "@angular/core";
import { OrderService } from "src/app/orders/order.service";
import { Order } from "src/app/orders/order";

@Component({
  selector: "app-right-sidebar",
  templateUrl: "./right-sidebar.component.html",
  styleUrls: ["./right-sidebar.component.css"],
})
export class RightSidebarComponent implements OnInit {
  @Input() order: Order;
  constructor(private orderService: OrderService) {
    // this.order = orderService.getPendingOrder();
  }

  ngOnInit() {}

  onDeleteItem(type: string, name: string, size: string) {
    const order = this.order;
    if (type === "burger") {
      console.log(order);
      order.burgerItems = order.burgerItems.filter(
        (b) => b.name !== name || b.size !== size
      );
      console.log(order);
    } else if (type === "side") {
      order.sideItems = order.sideItems.filter(
        (s) => s.name !== name || s.size !== size
      );
    } else if (type === "drink") {
      order.drinkItems = order.drinkItems.filter(
        (d) => d.name !== name || d.size !== size
      );
    }
    this.orderService.updatePendingOrder(order);
  }
}
