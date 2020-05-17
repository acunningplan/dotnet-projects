import { Component, OnInit } from "@angular/core";
import { OrderService } from "../orders/order.service";
import { Order } from "../orders/order";
import { MenuService } from "./menu.service";
import { Menu } from "./menu";
import { Food } from "./ingredients";
import { Burger } from "./menuJson";

@Component({
  selector: "app-menu",
  templateUrl: "./menu.component.html",
  styleUrls: ["./menu.component.css"],
})
export class MenuComponent implements OnInit {
  menu: Menu;
  order: Order;
  foodsToDisplay: Food[];
  foodType: string;
  showBurgerModal = false;

  constructor(
    private menuService: MenuService,
    private orderService: OrderService
  ) {}

  ngOnInit() {
    this.menu = this.menuService.getMenu();
    this.order = this.orderService.getPendingOrder();
  }

  preserveOrder = (a, b) => a;

  onClick() {}

  clickSubcategory({ foods, category }) {
    this.foodsToDisplay = foods;
    this.foodType = category;
  }

  addFoodToOrder(name: string, size: string) {
    const food = this.foodsToDisplay.find((bi) => bi.name === name);
    this.orderService.addToPendingOrder(food, this.foodType, size).subscribe();
  }

  burgerModal() {
    this.showBurgerModal = !this.showBurgerModal;
  }
}
