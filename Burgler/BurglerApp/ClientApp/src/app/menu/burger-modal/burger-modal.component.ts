import { Component, OnInit, Input } from "@angular/core";
import { Food, Ingredients } from "../ingredients";
import { BurgerItem, Menu } from "../menu";
import { OrderService } from "src/app/orders/order.service";
import { Order } from "src/app/orders/order";
import { MenuService } from "../menu.service";

@Component({
  selector: "app-burger-modal",
  templateUrl: "./burger-modal.component.html",
  styleUrls: ["./burger-modal.component.css"],
})
export class BurgerModalComponent implements OnInit {
  @Input() food: Food;
  @Input() option: { size: string; calories: string; price: string };
  burger: BurgerItem;
  order: Order;
  menu: Menu;
  ingredients: Ingredients;
  buns: string;

  constructor(
    private menuService: MenuService,
    private orderService: OrderService
  ) {}

  ngOnInit() {
    this.burger = this.food as BurgerItem;
    this.order = this.orderService.getPendingOrder();
    this.menu = this.menuService.getMenu();
    this.ingredients = this.menuService.getIngredients();
  }

  addBurgerToOrder() {}

  checkIfIngredientIsIncluded(listOfIngredients: string[], ing: string) {
    return !!listOfIngredients.find(i => i === ing)
  }
}
