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
  constructor(private orderService: OrderService) {}

  ngOnInit() {}

  getFoodItems() {
    const { burgerItems, sideItems, drinkItems } = this.order;
    return burgerItems.concat(sideItems).concat(drinkItems);
  }

  onDeleteItem(name: string, size: string) {
    this.orderService.deleteFromOrder(name, size).subscribe();
  }
}
