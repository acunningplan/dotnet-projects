import { Component, OnInit } from "@angular/core";
import { OrderService } from "../orders/order.service";
import { Order, BurgerItemJson } from "../orders/order";
import { MenuService } from "./menu.service";
import { Menu, BurgerItem } from "./menu";
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

  addBurgerToOrder(
    burger: BurgerItem,
    option: { size: string; calories: number; price: number }
  ) {
    this.orderService.addToPendingOrder(burger, "burgers", option).subscribe();
  }

  clickSubcategory({ foods, category }) {
    this.foodsToDisplay = foods;
    this.foodType = category;
  }

  addFoodToOrder(
    name: string,
    option: { size: string; calories: number; price: number },
    oneSize: boolean
  ) {
    const food = this.foodsToDisplay.find((bi) => bi.name === name);
    this.orderService
      .addToPendingOrder(food, this.foodType, option, oneSize)
      .subscribe();
  }

  burgerModal() {
    this.showBurgerModal = !this.showBurgerModal;
  }
}
