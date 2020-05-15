import { Component, OnInit, Input } from "@angular/core";
import { Food, Ingredients } from "../ingredients";
import { BurgerItem, Menu } from "../menu";
import { OrderService } from "src/app/orders/order.service";
import { Order, BurgerItemJson } from "src/app/orders/order";
import { MenuService } from "../menu.service";

@Component({
  selector: "app-burger-modal",
  templateUrl: "./burger-modal.component.html",
  styleUrls: ["./burger-modal.component.css"],
})
export class BurgerModalComponent implements OnInit {
  @Input() food: Food;
  @Input() option: { size: string; calories: number; price: number };
  burger: BurgerItem;
  burgerOrder: BurgerItemJson;
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
    this.burgerOrder = new BurgerItemJson(this.burger, this.option);
    this.order = this.orderService.getPendingOrder();
    this.menu = this.menuService.getMenu();
    this.ingredients = this.menuService.getIngredients();
  }

  addBurgerToOrder() {}

  checkIfIngredientIsIncluded(listOfIngredients: string[], ing: string) {
    return !!listOfIngredients.find((i) => i === ing);
  }

  chooseIng(ing: string, type: string) {
    if (type === "burgerBun") {
      this.burgerOrder.burgerBun = ing;
    } else if (type === "burgerToppings") {
      this.burgerOrder.addOrRemoveTopping(ing);
    } else if (type === "burgerPatty") {
      this.burgerOrder.burgerPatty = ing;
    } else if (type === "burgerPattyCooked") {
      this.burgerOrder.burgerPattyCooked = +ing;
    }
    console.log(this.burgerOrder);
  }

  addToOrder() {
    this.orderService.addCustomBurgerToPendingOrder(this.burgerOrder);
    console.log(this.orderService.getPendingOrder());
  }
}
