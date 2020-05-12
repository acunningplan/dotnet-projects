import { Component, OnInit, Input } from "@angular/core";
import { OrderService } from "src/app/orders/order.service";
import { Order, FoodItem } from "src/app/orders/order";

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
    let foodItems: FoodItem[] = [];
    const { burgerItems, sideItems, drinkItems } = this.order;
    foodItems = foodItems
      .concat(burgerItems)
      .concat(sideItems)
      .concat(drinkItems);
    return foodItems;
  }

  onDeleteItem(name: string, size: string) {
    this.orderService.deleteFromOrder(name, size).subscribe();
  }
}
