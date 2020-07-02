import { Component, Input } from "@angular/core";
import { FoodItem } from "../../order";

@Component({
  selector: "app-order-item",
  templateUrl: "./order-item.component.html",
  styleUrls: ["./order-item.component.css"],
})
export class OrderItemComponent {
  @Input() foodItem: FoodItem;
}
